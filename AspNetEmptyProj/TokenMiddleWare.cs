﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetEmptyProj
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        string _pattern;

        public TokenMiddleware(RequestDelegate next, string pattern)
        {
            this._next = next;
            this._pattern = pattern;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != _pattern)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}