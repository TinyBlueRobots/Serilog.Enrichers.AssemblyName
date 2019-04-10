namespace Serilog

open Serilog.Core

type Sink() =
  let events = ResizeArray<_>()
  member __.Events = events
  interface ILogEventSink with
    member __.Emit(logEvent) = events.Add logEvent