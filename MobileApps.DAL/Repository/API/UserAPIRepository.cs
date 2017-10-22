﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Models;

namespace MobileApps.DAL.Repository.API
{
    public class UserAPIRepository : BaseAPIRepository, IUserAPIRepository
    {
		public string Url { get; set; }

		public async Task<List<User>> GetUsersByOrganizationAsync(Organization organization, string language, string CRMConnectionString = "kiosk.collegelasalle.com")
		{
			if (string.IsNullOrEmpty(organization?.Name)) return null;
			Url = "http://" + CRMConnectionString +
				"" + organization.Name +
				  "" + language;
			return await GetAsync<List<User>>(Url);
		}
    }
}
