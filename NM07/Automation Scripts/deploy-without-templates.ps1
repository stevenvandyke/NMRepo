
#  --------------------------- Select Subscription  ---------------------------

Get-AzureRmSubscription -SubscriptionId "9f847037-9073-42ac-8cdc-6cfae23a6cab" -TenantId "4daa5164-f673-4721-a1b0-28d19ca8a964" | Set-AzureRmContext

#  --------------------------- Access Account  ---------------------------

Login-AzureRmAccount
Get-AzureRmLocation | select Location 
$location = "centralus"

#  --------------------------- Create New Storage Account  ---------------------------

$resourceGroup = "nm08-rg01"

$storageAccount = New-AzureRmStorageAccount -ResourceGroupName $resourceGroup `
  -Name "nm08storage01" `
  -Location $location `
  -SkuName Standard_LRS `
  -Kind Storage

$ctx = $storageAccount.Context

#  --------------------------- Create New Container ---------------------------

$containerName = "nm08storage01blob01"
New-AzureStorageContainer -Name $containerName -Context $ctx -Permission blob

#  --------------------------- Create New Table ---------------------------

$tableName = "nm08storage01table01"
New-AzureStorageTable -Name $tableName -Context $ctx
