module EulaTests

open Expecto
open MinecraftConfig.Eula

[<Tests>]
let tests =
  testList "EULA tests" [
    testCase "Generates agreed EULA" <| fun _ ->
      let eulaContent = format true
      Expect.stringEnds (eulaContent.TrimEnd()) "eula=True" "Incorrect payload for EULA"
      Expect.equal Filename "eula.txt" "Incorrect filename to generate"
  ]
