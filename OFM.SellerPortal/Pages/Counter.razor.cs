using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using OFM.SellerPortal;
using OFM.SellerPortal.Shared;
using OFM.SellerPortal.Cores;
using OFM.SellerPortal.ViewModels.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;

namespace OFM.SellerPortal.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;
        private void IncrementCount()
        {
            currentCount++;
        }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }
    }
}