param($installPath, $toolsPath, $package, $project)

Write-Host "Setting Application to DowJones.Web.Mvc.HttpApplication..."

# Read the transformed text from the custom template included in the package
$customInit = $project.ProjectItems | where { $_.Name -eq "init.js.custom" }
if(!$customInit) {
Write-Host "Not exist init.js.custom"
}
$customInit.Open()
$customInit.Document.Activate()
$customInit.Document.Selection.SelectAll(); 
$replacementInit = $customInit.Document.Selection.Text;
$customInit.Delete()
	$packagesFolder = Split-Path -Path $installPath -Parent
	Write-Host "$packagesFolder"
	Write-Host $packagesFolder
	$packagesFolder+"\Scripts"
		Write-Host "$packagesFolder+Scripts"
	Write-Host $packagesFolder
# Replace the contents of Global.asax.cs
$InitJs = $project.ProjectItems | where { $_.Name -eq "\Scripts\init.js" }
	Write-Host "$InitJs"
	Write-Host $InitJs
if($InitJs) {
	$InitJs.Open()
	$InitJs.Document.Activate()
    $InitJs.Document.ReplaceText("require(['knockout'", "require(['knockout','Components/CropImage/CropImage'")    
    $InitJs.Document.ReplaceText(" ko.applyBindings();", " ko.components.register('crop-image', {viewModel: Components.CropImage,template: { require: 'text!Components/CropImage/template/template.html'}}); `n ko.applyBindings();") 
	$InitJs.Document.Selection.StartOfDocument()
	$InitJs.Document.Close(0)
}
else {

}