module EulaTests

open Expecto
open MinecraftConfig

[<Tests>]
let tests =
  testList "EULA tests" [
    testCase "Generates agreed EULA" <| fun _ ->
      let eulaContent = Eula.format true
      Expect.stringEnds (eulaContent.TrimEnd()) "eula=True" "Incorrect payload for EULA"
      Expect.equal Eula.Filename "eula.txt" "Incorrect filename to generate"
  ]
