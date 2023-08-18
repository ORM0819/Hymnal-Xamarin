using System;
using System.Collections.Generic;
using Hymnal.AzureFunctions.Models;

namespace Hymnal.AzureFunctions.Client;

public interface IAzureHymnService
{
    IObservable<IEnumerable<HymnSettingsResponse>> ObserveSettings(bool reload = false);
}
