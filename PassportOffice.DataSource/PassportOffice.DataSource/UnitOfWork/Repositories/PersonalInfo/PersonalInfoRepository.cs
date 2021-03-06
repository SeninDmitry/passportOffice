﻿namespace PassportOffice.DataSource.UnitOfWork.Repositories.PersonalInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PassportOffice.DataSource.Context;
    using PassportOffice.DataSource.Model;

    /// <summary>
    /// Repository with personal data based on database context.
    /// </summary>
    public class PersonalInfoRepository : IPersonalInfoRepositiry
    {
        /// <summary>
        /// Current context of database.
        /// </summary>
        private PassportOfficeContext passportOfficeContext;

        /// <summary>
        /// Flag which identifies that object was already disposed.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Create an instance of <see cref="PersonalInfoRepository"/> class.
        /// </summary>
        /// <param name="passportOfficeContext">Context of current database.</param>
        internal PersonalInfoRepository(PassportOfficeContext passportOfficeContext)
        {
            this.passportOfficeContext = passportOfficeContext;
        }

        /// <summary>
        /// Finds all data at database.
        /// </summary>
        /// <returns>All records from database.</returns>
        public IEnumerable<PersonInfo> GetAll()
        {
            return this.passportOfficeContext.Persons.ToList();
        }

        /// <summary>
        /// Finds record with concete unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier of record at database.</param>
        /// <returns>Record with Id equals to passed parameter.</returns>
        public PersonInfo GetById(int id)
        {
            return this.passportOfficeContext.Persons.FirstOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// Save changes of repository.
        /// </summary>
        public void Save()
        {
            this.passportOfficeContext.SaveChanges();
        }

        /// <summary>
        /// Dispose current instance.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose current instance.
        /// </summary>
        /// <param name="disposing">Flag which identifies that disposing was invoked by user.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.passportOfficeContext.Dispose();
                }

                this.disposed = true;
            }
        }
    }
}
