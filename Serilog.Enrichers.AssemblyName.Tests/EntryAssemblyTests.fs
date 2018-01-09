module EntryAssemblyTests

open Serilog
open Expecto
open System.IO

let setup =
  lazy
    let sink = Sink()
    Log.Logger <- LoggerConfiguration().WriteTo.Sink(sink).Enrich.WithAssemblyName().Enrich.WithAssemblyVersion().CreateLogger()
    sink

[<Tests>]
let tests =

  testList "entry assembly" [

    test "assembly name" {
      let sink = setup.Value
      Log.Information "Test"
      let event = sink.Events |> Seq.head
      use output = new StringWriter()
      event.Properties.["AssemblyName"].Render output
      let assemblyName = output.ToString()
      Expect.equal assemblyName "\"Serilog.Enrichers.AssemblyName.Tests\"" "assembly name"
    }

    test "assembly version" {
      let sink = setup.Value
      Log.Information "Test"
      let event = sink.Events |> Seq.head
      use output = new StringWriter()
      event.Properties.["AssemblyVersion"].Render output
      let assemblyVersion = output.ToString()
      Expect.equal assemblyVersion "\"1.2.3.4\"" "assembly version"
    }

  ]