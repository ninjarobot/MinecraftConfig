module ServerPropertiesTests

open System
open Expecto
open MinecraftConfig

[<Tests>]
let tests =
  testList "Server Properties tests" [
    testCase "Generates agreed EULA" <| fun _ ->
      let props = [
          ServerProperty.Gamemode "Survival"
          ServerProperty.AllowNether true
          ServerProperty.AllowFlight true
      ]
      let expectedProps = """gamemode=Survival
allow-nether=True
allow-flight=True"""
      let serverProperties = props |> List.map ServerProperties.format |> String.concat Environment.NewLine
      Expect.equal serverProperties expectedProps "Incorrect payload for server.properties"
      Expect.equal ServerProperties.Filename "server.properties" "Incorrect filename to generate"

    testCase "Generates server.properties file" <| fun _ ->
      System.IO.File.Delete "server.properties"
      [
          ServerProperty.Gamemode "Survival"
          ServerProperty.AllowNether true
          ServerProperty.AllowFlight true
      ] |> writeServerProperties
      Expect.isTrue (System.IO.File.Exists "server.properties") "Didn't generate server.properties file"

    testCase "Generates default server.properties file" <| fun _ ->
      System.IO.File.Delete "server.properties"
      defaultProperties |> writeServerProperties
      Expect.isTrue (System.IO.File.Exists "server.properties") "Didn't generate default server.properties file"
  ]

