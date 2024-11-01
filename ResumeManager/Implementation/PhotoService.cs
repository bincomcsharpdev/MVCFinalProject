using ResumeManager.Models;

public class PhotoService
{
    private readonly HttpClient _httpClient;

    public PhotoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://anthoniaresumemangerwebapi-f0ccb0argmfgdzgt.canadacentral-01.azurewebsites.net/api/photo/");
    }

    public async Task<bool> UploadPhotoAsync(PhotoUploadDto upload)
    {
        var content = new MultipartFormDataContent();
        content.Add(new StreamContent(upload.File.OpenReadStream()), "file", upload.File.FileName);
        var response = await _httpClient.PostAsync("upload", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdatePhotoDetailsAsync(int id, Anthonia_PhotohDto updatePhoto)
    {
        var response = await _httpClient.PutAsJsonAsync($"update_photo/{id}", updatePhoto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeletePhotoAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"delete_photo/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<PhotoDto?> GetPhotoDetailsAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<PhotoDto>($"view_details/{id}");
    }

    public async Task<IEnumerable<PhotoDto>> GetAllPhotosAsync(int page = 1, int pageSize = 10)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<PhotoDto>>($"gallery?page={page}&pageSize={pageSize}");
    }

    public async Task<byte[]?> GetImageAsync(int id)
    {
        var response = await _httpClient.GetAsync($"view_photo/image/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsByteArrayAsync();
        }
        return null;
    }
}
