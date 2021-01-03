module OpsTests

open Expecto
open MinecraftConfig

[<Tests>]
let tests =
  testList "Ops tests" [
    testCase "Generates ops.json for users" <| fun _ ->
      let uuid = "ff99afd0-cf80-4c8e-86bd-1e616f4113b0"
      let op = { Name="Foo"; Uuid= uuid; Level=OperatorLevel.Level4 }
      let json = [ op ] |> Ops.format
      let expectedJson = """[
  {
    "name": "Foo",
    "uuid": "ff99afd0-cf80-4c8e-86bd-1e616f4113b0",
    "level": 4
  }
]"""
      Expect.equal json expectedJson "Incorrect payload for whitelist"
      Expect.equal Ops.Filename "ops.json" "Incorrect filename to generate"
  ]
