﻿// This software is part of the Autofac IoC container
// Copyright © 2011 Autofac Contributors
// https://autofac.org
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

using System;
using Autofac.Core.Resolving.Pipeline;

namespace Autofac.Core.Resolving.Middleware
{
    /// <summary>
    /// Middleware added by default to the end of all service pipelines that invokes the registration's pipeline.
    /// </summary>
    internal class RegistrationPipelineInvokeMiddleware : IResolveMiddleware
    {
        /// <summary>
        /// Gets the singleton instance of this middleware.
        /// </summary>
        public static RegistrationPipelineInvokeMiddleware Instance { get; } = new RegistrationPipelineInvokeMiddleware();

        private RegistrationPipelineInvokeMiddleware()
        {
        }

        /// <inheritdoc/>
        public PipelinePhase Phase => PipelinePhase.ServicePipelineEnd;

        /// <inheritdoc/>
        public void Execute(IResolveRequestContext context, Action<IResolveRequestContext> next)
        {
            context.Registration.ResolvePipeline.Invoke(context);
        }

        /// <inheritdoc/>
        public override string ToString() => nameof(RegistrationPipelineInvokeMiddleware);
    }
}