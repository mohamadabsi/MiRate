﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICachingService.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Contracts
{
    /// <summary>
    /// The CachingService interface.
    /// </summary>
    public interface ICachingService
    {
        void UpdateCache<T>(string key, T value);

        T GetFromCaChe<T>(string key);


    }
}