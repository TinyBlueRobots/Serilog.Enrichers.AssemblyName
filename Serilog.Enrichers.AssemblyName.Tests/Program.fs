module Program

open Expecto

[<EntryPoint>]
let main args =
  Array.append args [| "--sequenced" |]
  |> runTestsInAssembly defaultConfig
