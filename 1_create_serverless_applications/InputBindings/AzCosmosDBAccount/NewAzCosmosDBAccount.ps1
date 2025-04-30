
MyResourceGroupName=(Get-AzResourceGroup).ResourceGroupName
MyLocation=(Get-AzResourceGroup).Location

New-AzCosmosDBAccount -ResourceGroupName $MyReSourceGroupName -Name myothet2025cosmosdbacc -Location westus
