using Microsoft.JSInterop;

namespace GipSite;

public class Dashboard
{
	private readonly IJSRuntime js;

	public Dashboard(IJSRuntime js)
	{
		this.js = js;
		//Do tha funny and render and abstract chart here (use accessors to update graph)
	}
}


//protected override void OnInitialized() => AfterInit();
//private async void AfterInit() => await JS.InvokeVoidAsync("RenderMainGraph");