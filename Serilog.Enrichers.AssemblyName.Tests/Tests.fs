module Tests

open Serilog.Core
open Serilog
open Expecto
open System.IO

type Sink() =
  let events = ResizeArray<_>()
  member __.Events = events
  interface ILogEventSink with
    member __.Emit(logEvent) = events.Add logEvent

let sink = Sink()
Log.Logger <- LoggerConfiguration().WriteTo.Sink(sink).Enrich.WithAssemblyName().Enrich.WithAssemblyVersion().CreateLogger()

[<Tests>]
let tests =

  testList "assembly info" [

    test "assembly name" {
      Log.Information "Test"
      let event = sink.Events |> Seq.head
      use output = new StringWriter()
      event.Properties.["AssemblyName"].Render output
      let assemblyName = output.ToString()
      Expect.equal assemblyName "\"Serilog.Enrichers.AssemblyName.Tests\"" "assembly name"
      }

    test "assembly version" {
      Log.Information "Test"
      let event = sink.Events |> Seq.head
      use output = new StringWriter()
      event.Properties.["AssemblyVersion"].Render output
      let assemblyVersion = output.ToString()
      Expect.equal assemblyVersion "\"0.0.0.0\"" "assembly version"
     }

  ]