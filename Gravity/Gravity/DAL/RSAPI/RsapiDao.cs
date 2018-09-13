﻿using System;
using Gravity.Globals;
using Gravity.Utils;
using Relativity.API;

namespace Gravity.DAL.RSAPI
{
	public partial class RsapiDao : IGravityDao
	{
		private const int DefaultBatchSize = 1000;

		protected InvokeWithRetryService invokeWithRetryService;
		protected IRsapiProvider rsapiProvider;
		protected ChoiceCache choiceCache;
		protected ArtifactGuidCache guidCache;
		protected FileMD5Cache fileMd5Cache;

		public RsapiDao(IServicesMgr servicesManager, int workspaceId, ExecutionIdentity executionIdentity,
				InvokeWithRetrySettings invokeWithRetrySettings = null,
				int batchSize = DefaultBatchSize)
			: this(servicesManager, workspaceId, executionIdentity, GetInvokeWithRetryService(invokeWithRetrySettings), batchSize)

		{
		}

		private RsapiDao(IServicesMgr servicesManager, int workspaceId, ExecutionIdentity executionIdentity,
				InvokeWithRetryService invokeWithRetryService,
				int batchSize = DefaultBatchSize)
			: this(new RsapiProvider(servicesManager, executionIdentity, invokeWithRetryService, workspaceId, batchSize))
		{
			this.invokeWithRetryService = invokeWithRetryService;
		}

		public RsapiDao(IRsapiProvider rsapiProvider)
		{
			this.rsapiProvider = rsapiProvider;
			this.choiceCache = new ChoiceCache(this.rsapiProvider);
			this.guidCache = new ArtifactGuidCache(this.rsapiProvider);
			this.fileMd5Cache = new FileMD5Cache(this.rsapiProvider);
		}

		private static InvokeWithRetryService GetInvokeWithRetryService(InvokeWithRetrySettings invokeWithRetrySettings)
		{
			if (invokeWithRetrySettings == null)
			{
				invokeWithRetrySettings = new InvokeWithRetrySettings(SharedConstants.retryAttempts, SharedConstants.sleepTimeInMiliseconds);
			}

			return new InvokeWithRetryService(invokeWithRetrySettings);
		}
	}
}