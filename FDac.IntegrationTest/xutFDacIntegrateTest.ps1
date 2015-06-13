####
## .\packages\xunit.runner.console.2.0.0\tools\xunit.console.exe .\FDac.IntegrationTest\bin\Debug\FDac.IntegrationTest.dll

####
## get one directory out of the position of this script, the root of the solution where the packages dir is
$DEPLOYMENT_SOURCE = (Get-Item -Path ".\.." -Verbose).FullName 
$XUNIT_CONSOLE = "$DEPLOYMENT_SOURCE\packages\xunit.runner.console.2.0.0\tools\xunit.console.exe"

####
$XUNIT_TEST_ITEM = "FDac.IntegrationTest"
$XUNIT_TEST_DLL = "$XUNIT_TEST_ITEM.dll"
$DLL_PATH = "$DEPLOYMENT_SOURCE\FDac.IntegrationTest\bin\Debug\$XUNIT_TEST_DLL"

####
##$TRAITS = "-trait `"category=DataAccessCrudFs`""
$TRAITS = "-trait `"category=AutoGenSql`""
##$TRAITS = "-trait `"category=DataAccessTypesFs`""
$command = "$XUNIT_CONSOLE  $DLL_PATH  $TRAITS -html $XUNIT_TEST_ITEM.Results.html -xml $XUNIT_TEST_ITEM.Results.xml "
iex $command
