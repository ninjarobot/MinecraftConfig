module UserWhitelistTests

open Expecto
open MinecraftConfig

[<Tests>]
let tests =
  testList "whitelist tests" [
    testCase "Generates whitelist for users" <| fun _ ->
      let uuid1 = "f27fe889-cb34-48b2-996e-9f7fb8e58357"
      let user1 = { Name="Foo"; Uuid= uuid1 }
      let uuid2 = "90450cca-ad1c-45c9-ab6a-06ae96f539b2"
      let user2 = { Name="Bar"; Uuid= uuid2 }
      let json = [ user1; user2 ] |> Whitelist.format
      let expectedJson = """[
  {
    "name": "Foo",
    "uuid": "f27fe889-cb34-48b2-996e-9f7fb8e58357"
  },
  {
    "name": "Bar",
    "uuid": "90450cca-ad1c-45c9-ab6a-06ae96f539b2"
  }
]"""
      Expect.equal json expectedJson "Incorrect payload for whitelist"
      Expect.equal Whitelist.Filename "whitelist.json" "Incorrect filename to generate"
  ]