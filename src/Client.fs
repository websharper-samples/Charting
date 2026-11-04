namespace Samples

open WebSharper
open WebSharper.Charting
open WebSharper.ChartJs
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Templating

/// A radar chart built with the high-level WebSharper.Charting API.
[<JavaScript>]
module Client =

    type Template = Templating.Template<"wwwroot/index.html", ClientLoad.FromDocument>

    let private labels =
        [| "Eating"; "Drinking"; "Sleeping"; "Designing"; "Coding"; "Cycling"; "Running" |]

    let private radar title values fill stroke point =
        Chart.Radar(Array.zip labels values)
            .WithTitle(title)
            .WithFillColor(fill)
            .WithStrokeColor(stroke)
            .WithPointColor(point)

    [<SPAEntryPoint>]
    let Main () =
        let chart =
            Chart.Combine [
                radar "Alice" [| 28.0; 48.0; 40.0; 19.0; 96.0; 27.0; 100.0 |]
                    (Color.Rgba(99, 102, 241, 0.20))
                    (Color.Rgba(99, 102, 241, 1.0))
                    (Color.Rgba(79, 70, 229, 1.0))
                radar "Bob" [| 65.0; 59.0; 90.0; 81.0; 56.0; 55.0; 40.0 |]
                    (Color.Rgba(14, 165, 233, 0.20))
                    (Color.Rgba(14, 165, 233, 1.0))
                    (Color.Rgba(2, 132, 199, 1.0))
            ]

        // Fill the card rather than using a fixed canvas size.
        let options = RadarChartOptions()
        options.Responsive <- true
        options.MaintainAspectRatio <- false

        Template()
            .Chart(Renderers.ChartJs.Render(chart, Size = Size(500, 400), Config = options))
            .Bind()
