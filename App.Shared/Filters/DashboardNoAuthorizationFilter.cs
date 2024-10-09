using Hangfire.Dashboard;

namespace App.Shared.Filters;

public class DashboardNoAuthorizationFilter : IDashboardAuthorizationFilter
{
  public bool Authorize(DashboardContext dashboardContext)
  {
    return true;
  }
}