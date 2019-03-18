#load ".cake/Configuration.cake"

/**********************************************************/
Setup<Configuration>(Configuration.Create);
/**********************************************************/

#load ".cake/CI.cake"

// -- DotNetCore
#load ".cake/Restore-DotNetCore.cake"
#load ".cake/Build-DotNetCore.cake"
#load ".cake/Publish-Zip-DotNetCore.cake"
#load ".cake/Publish-Pack-DotNetCore.cake"
#load ".cake/Test-XUnit2.cake"
#load ".cake/Artifacts-DotNetCore-Ef.cake"
// -------------

RunTarget(Argument("target", Argument("Target", "Default")));