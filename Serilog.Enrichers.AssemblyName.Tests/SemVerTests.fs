module SemverTests

open Serilog
open Expecto
open System.IO

let setup =
  lazy
    let sink = Sink()
    Log.Logger <- LoggerConfiguration().WriteTo.Sink(sink).Enrich.WithAssemblyName<Sink>().Enrich.WithAssemblyVersion(true).CreateLogger()
    sink

[<Tests>]
let tests =

  testList "assembly" [

    test "assembly version is 1.2.3" {
      let sink = setup.Value
      Log.Information "Test"
      let event = sink.Events |> Seq.head
      use output = new StringWriter()
      event.Properties.["AssemblyVersion"].Render output
      let assemblyVersion = output.ToString()
      Expect.equal assemblyVersion "\"1.2.3\"" "assembly version"
    }

  ]