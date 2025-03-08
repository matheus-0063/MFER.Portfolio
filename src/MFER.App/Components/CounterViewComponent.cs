using Microsoft.AspNetCore.Mvc;

namespace MFER.App.Components;

/*Para a classe ser uma ViewComponent, ela precisa
 herdar de ViewComponent e implementar o método InvokeAsync
 */

public class CounterViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(int modelCounter)
    {
        return View(modelCounter);
    }
}