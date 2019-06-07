#load ".cake/Configuration.cake"

/**********************************************************/
Setup<Configuration>(Configuration.Create);
/**********************************************************/

#load ".cake/CI.cake"

#load ".cake/Restore-NuGet.cake"
#load ".cake/Build-MsBuild.cake"
#load ".cake/Test-XUnit2.cake"
#load ".cake/Publish-Pack-NuGet.cake"

RunTarget(Argument("target", Argument("Target", "Default")));