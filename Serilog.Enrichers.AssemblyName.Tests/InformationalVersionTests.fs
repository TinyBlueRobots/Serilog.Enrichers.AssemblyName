module InformationalVersionTests

open Serilog
open Expecto
open System.IO

let setup =
  lazy
    let sink = Sink()
    Log.Logger <- LoggerConfiguration().WriteTo.Sink(sink).Enrich.WithAssemblyInformationalVersion().CreateLogger()
    sink

[<Tests>]
let tests =

  testList "informational version" [

    test "assembly informational version is 1.2.3.4-rc" {
      let sink = setup.Value
      Log.Information "Test"
      let event = sink.Events |> Seq.head
      use output = new StringWriter()
      event.Properties.["AssemblyVersion"].Render output
      let assemblyVersion = output.ToString()
      Expect.equal assemblyVersion "\"1.2.3.4-rc\"" "assembly version"
    }

  ]
