# Define your storage account and resource group
$resourceGroup = Get-AzResourceGroup | Select-Object ResourceGroupName
$storageAccountName = "acglearnmyothetstgacc"

# Get storage account context
$storageAccount = Get-AzStorageAccount -ResourceGroupName $resourceGroup -Name $storageAccountName
$ctx = $storageAccount.Context

# Create the container using the correct context object
# New-AzStorageContainer -Name "container2" -Permission blob -Context $ctx
New-AzStorageContainer -Name "container1" -Permission off -Context $ctx