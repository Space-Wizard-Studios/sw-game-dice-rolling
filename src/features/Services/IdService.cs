using System;

namespace DiceRolling.Services;

public static class IdService {
    public static string GenerateNewId() {
        return Guid.NewGuid().ToString();
    }

    public static void EnsureValidId(ref string id) {
        if (ValidationService.IsNullOrEmpty(id)) {
            id = GenerateNewId();
        }
    }
}