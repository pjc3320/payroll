﻿using System;
using Couchbase;
using Couchbase.N1QL;

namespace Payroll.Application.Couchbase
{
    public static class ResultExtensions
    {
        public static void ThrowIfFailure(this IDocumentResult result)
        {
            if (result.Success) return;

            result.EnsureSuccess();
        }

        public static void ThrowIfFailure<T>(this IQueryResult<T> result)
        {
            if (result.Success) return;

            result.EnsureSuccess();
        }

        internal static void ThrowIfFailure(this IResult result)
        {
            if (result.Success) return;


            if (!result.Success)
            {
                throw result.Exception;
            }
        }
    }
}