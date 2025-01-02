function Get-ClassName {
    param (
        [string]$fileContent
    )

    $classNamePattern = [regex]::new('public\s+(partial\s+)?class\s+(\w+)')
    $match = $classNamePattern.Match($fileContent)
    if ($match.Success) {
        return $match.Groups[2].Value
    }
    return $null
}

$directoryPath = "src" # Adjust the path as needed
$files = Get-ChildItem -Path $directoryPath -Recurse -Filter *.cs

foreach ($file in $files) {
    $fileNameWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($file)
    $fileContent = Get-Content -Path $file.FullName -Raw

    $className = Get-ClassName -fileContent $fileContent

    if ($className -and $className -ne $fileNameWithoutExtension) {
        Write-Output "Mismatch found: File '$fileNameWithoutExtension' contains class '$className'"
    }
}