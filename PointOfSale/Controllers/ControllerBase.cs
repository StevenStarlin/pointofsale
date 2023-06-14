﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PointOfSale.Controllers;
using PointOfSale_Entities.Models;
using System.Data.Entity;

namespace PointOfSaleAPI.Controllers
{
    internal class ControllerBase<T> : Controller where T : class
    {
        private readonly ILogger<T> _logger;
        private int defaultPageSize => 30;
        private readonly PointOfSaleContext context;
        private Microsoft.EntityFrameworkCore.DbSet<T> databaseSet;

        public ControllerBase(ILogger<T> logger)
        {
            this._logger = logger;

            // ??= is here in case an unknown entry somehow makes
            // its way in here through threading or something. It may be unnecessary
            // but I think being over safe in this case isn't awful.
            this.context ??= ContextRepository.Instance.DatabaseContext;
            databaseSet = this.context.Set<T>();
        }

        /// <summary>
        /// Set record "IsActive" flag to false instead of destructive deletion.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>If a non-zero number of records were affected.</returns>
        internal bool Delete(T entity)
        {
            int recordsAffected = 0;
            var propertyHasBeenSet = TrySetProperty(entity, "IsActive", false);

            // Bail out if the property can't be set for some reason.
            // This increases some performance because we're not trying
            // to fire an update to the database every time this method
            // is called.
            if (!propertyHasBeenSet)
            {
                return false;
            }

            try
            {
                this.databaseSet.Update(entity);
                recordsAffected = this.context.SaveChanges();
            }
            catch(Exception ex)
            {
                var errorMessage = $"Error marking record for deletion in table {typeof(T)}.";
                errorMessage += $"\n{ex.Message}";
                errorMessage += $"\n{ex.StackTrace}";

                _logger.LogError(errorMessage);
            }

            return recordsAffected != 0;
        }

        /// <summary>
        /// Get a list of records leveraging a page size and page number
        /// </summary>
        /// <param name="recordsPerPage">Default 30</param>
        /// <param name="pageNumber">Default 0 (skip no records)</param>
        /// <returns>List of requested objects</returns>
        internal IEnumerable<T> Get(int? recordsPerPage, int? pageNumber)
        {
            var recordCount = recordsPerPage ?? defaultPageSize;

            // The first page should not skip any records, therefore we
            // multiply our record number by 0- it's 0 records skipped.
            var recordsToSkip = recordCount * (pageNumber ?? 0);

            var entities = new List<T>();

            try
            {
                entities = this.databaseSet
                    .Skip(recordsToSkip) // Essentially the calculated "page" of records
                    .Take(recordCount) // The records to return.
                    as List<T>
                    ?? new List<T>();
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error finding a values on page {pageNumber} in table {typeof(T)}.";
                errorMessage += $"\n{ex.Message}";
                errorMessage += $"\n{ex.StackTrace}";

                _logger.LogError(errorMessage);
            }

            return entities;
        }

        /// <summary>
        /// Get single record from the database by the record id
        /// </summary>
        /// <param name="id">The record primary key integer</param>
        /// <returns>A nullable object of the desired type</returns>
        internal T? Get(int? id)
        {
            if (id == null)
            {
                return null;
            }

            T? foundValue = default;

            try
            {
                foundValue = this.databaseSet.Find(id) ?? null;
            } 
            catch (Exception ex)
            {
                var errorMessage = $"Error finding a value for ID {id} in table {typeof(T)}.";
                errorMessage += $"\n{ex.Message}";
                errorMessage += $"\n{ex.StackTrace}";

                _logger.LogError(errorMessage);
            }

            return foundValue;
        }

        /// <summary>
        /// Insert the object into the database.
        /// </summary>
        /// <param name="record">The desired object to insert.</param>
        /// <returns>The newly populated object (including the id generated by insertion)</returns>
        public T? Post(T record)
        {
            EntityEntry<T>? insertedEntity = null;

            try
            {
                insertedEntity = this.databaseSet.Add(record);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error inserting record into table {typeof(T)}.";
                errorMessage += $"\n{ex.Message}";
                errorMessage += $"\n{ex.StackTrace}";

                _logger.LogError(errorMessage);
            }

            return insertedEntity?.Entity ?? default;
        }

        private bool TrySetProperty(object obj, string property, object value)
        {
            var baseClassProperty = obj.GetType().GetProperty(property);

            if (baseClassProperty == null || !baseClassProperty.CanWrite)
            {
                return false;
            }

            baseClassProperty.SetValue(obj, value, null);

            return true;
        }
    }
}
