﻿namespace PassportOffice.DataSource.UnitOfWork
{
    using System;

    using PassportOffice.DataSource.Context;
    using PassportOffice.DataSource.UnitOfWork.Repositories.PersonalInfo;

    /// <summary>
    /// Container of repositories working with database.
    /// It guarantees that all repositories will work with one context of database.
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        /// <summary>
        /// Flag which identifies that object was already disposed.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Context of database.
        /// </summary>
        private PassportOfficeContext passportOfficeContext = new PassportOfficeContext();

        /// <summary>
        /// Repository with personal infornation.
        /// </summary>
        private IPersonalInfoRepositiry personalInfoRepo;

        /// <summary>
        /// Get/set repository with personal data.
        /// </summary>
        public IPersonalInfoRepositiry PersonalInfoRepository
        {
            get
            {
                if (this.personalInfoRepo == null)
                {
                    this.personalInfoRepo = new PersonalInfoRepository(this.passportOfficeContext);
                }

                return this.personalInfoRepo;
            }
        }

        /// <summary>
        /// Dispose current object.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose current object.
        /// </summary>
        /// <param name="disposing">Flag which identifies that process of disposing was invoked by user.</param>
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
