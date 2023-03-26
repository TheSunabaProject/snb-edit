﻿using System;

namespace SunabaSDK.Providers
{
    public class ProviderException : Exception
    {
        public ProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ProviderException()
        {
        }

        public ProviderException(string message) : base(message)
        {
        }
    }
}
