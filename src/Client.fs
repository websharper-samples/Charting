module RadarChart

open WebSharper
open WebSharper.Charting
open WebSharper.UI
open WebSharper.UI.Client

[<SPAEntryPoint>]
let Main() =
    let labels =
        [| "Eating"; "Drinking"; "Sleeping";
           "Designing"; "Coding"; "Cycling"; "Running" |]
    let dataset1 = [|28.0; 48.0; 40.0; 19.0; 96.0; 27.0; 100.0|]
    let dataset2 = [|65.0; 59.0; 90.0; 81.0; 56.0; 55.0; 40.0|]
    
    let chart =
        Chart.Combine [
            Chart.Radar(Array.zip labels dataset1)
                .WithFillColor(Color.Rgba(151, 187, 205, 0.2))
                .WithStrokeColor(Color.Name "blue")
                .WithPointColor(Color.Name "darkblue")
                .WithTitle("Alice")

            Chart.Radar(Array.zip labels dataset2)
                .WithFillColor(Color.Rgba(220, 220, 220, 0.2))
                .WithStrokeColor(Color.Name "green")
                .WithPointColor(Color.Name "darkgreen")
                .WithTitle("Bob")
        ]
    
    Renderers.ChartJs.Render(chart, Size = Size(500, 300)).RunById "main"
