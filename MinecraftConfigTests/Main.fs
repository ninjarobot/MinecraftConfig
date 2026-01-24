module MinecraftConfigTests
open Expecto

[<EntryPoint>]
let main argv =
    Tests.runTestsWithCLIArgs [] argv (
        testList "All tests" [
            EulaTests.tests
            OpsTests.tests
            ServerPropertiesTests.tests
            UserWhitelistTests.tests
        ]
    )