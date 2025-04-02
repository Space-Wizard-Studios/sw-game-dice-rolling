# ClassNameChecker.ps1
function Get-PrimaryTypeName {
    param (
        [string]$fileContent
    )

    # Check for class, interface, struct, or record declarations
    $typePatterns = @(
        'public\s+(partial\s+)?class\s+(\w+)',
        'public\s+(partial\s+)?interface\s+(\w+)',
        'public\s+(partial\s+)?struct\s+(\w+)',
        'public\s+(partial\s+)?record\s+(\w+)'
    )
    
    foreach ($pattern in $typePatterns) {
        $match = [regex]::new($pattern).Match($fileContent)
        if ($match.Success) {
            return $match.Groups[2].Value
        }
    }
    return $null
}

# Begin script execution
Write-Output "Class Name Checker - Started at $(Get-Date)"
Write-Output "---------------------------------------"

$directoryPath = "src" 
# Get all C# files but exclude the .godot directory and generated files
$files = Get-ChildItem -Path $directoryPath -Recurse -Filter *.cs -Exclude "*.g.cs", "*.Designer.cs" | 
Where-Object { $_.FullName -notmatch "[\\/]\.godot[\\/]" }

$mismatchCount = 0
$matchCount = 0

Write-Output "Checking for class name mismatches..."

foreach ($file in $files) {
    $fileNameWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($file)
    $fileContent = Get-Content -Path $file.FullName -Raw

    $typeName = Get-PrimaryTypeName -fileContent $fileContent

    if ($typeName -and $typeName -ne $fileNameWithoutExtension) {
        Write-Output "MISMATCH: File '$($file.FullName)' contains type '$typeName'"
        $mismatchCount++
    }
    elseif ($typeName) {
        Write-Output "MATCH: File '$($file.FullName)' correctly contains type '$typeName'"
        $matchCount++
    }
    else {
        Write-Output "NO TYPE: File '$($file.FullName)' does not contain a public type declaration"
    }
}

Write-Output "---------------------------------------"
Write-Output "Summary:"
Write-Output "  Total files checked: $($files.Count)"
Write-Output "  Matches found: $matchCount"
Write-Output "  Mismatches found: $mismatchCount"
Write-Output "  Files without type declarations: $($files.Count - $matchCount - $mismatchCount)"

if ($mismatchCount -eq 0) {
    Write-Output "All class names match their filenames. Great job!"
}
else {
    Write-Output "Found $mismatchCount file(s) with mismatched type names."
}