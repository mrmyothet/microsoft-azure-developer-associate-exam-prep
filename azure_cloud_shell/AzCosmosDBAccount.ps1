New-AzCosmosDBAccount `
  -ResourceGroupName learn-2862aba5-dded-40c7-9729-501dd5a9fe48 `
  -Name myothetmslearndbacc `
  -Location "West US 3"

New-AzCosmosDBSqlDatabase `
  -ResourceGroupName learn-2862aba5-dded-40c7-9729-501dd5a9fe48 `
  -AccountName myothetmslearndbacc `
  -Name sqldatabase1

New-AzCosmosDBSqlContainer `
  -ResourceGroupName "learn-2862aba5-dded-40c7-9729-501dd5a9fe48" `
  -AccountName "myothetmslearndbacc" `
  -DatabaseName "sqldatabase1" `
  -Name "container1" `
  -PartitionKeyKind "Hash" `
  -PartitionKeyPath "/id"

$resourceGroup = "learn-2862aba5-dded-40c7-9729-501dd5a9fe48"
$accountName = "myothetmslearndbacc"
$databaseName = "sqldatabase1"
$containerName = "container1"


$item = @{
  "id"  = "docs"
  "url" = "https://learn.microsoft.com/azure"
}
$jsonItem = $item | ConvertTo-Json -Depth 10


New-AzCosmosDBSqlStoredProcedure `
  -ResourceGroupName $resourceGroup `
  -AccountName $accountName `
  -DatabaseName $databaseName `
  -ContainerName $containerName `
  -StoredProcedureName "InsertItem" `
  -Body $jsonItem
