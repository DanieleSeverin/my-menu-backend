﻿namespace Application.Users.LogInUser;

public sealed record LogInResponse(string AccessToken, string RefreshToken);