export function ucfirst(text)
{
    return text.charAt(0).toUpperCase() + text.slice(1);
}

export function formatDuration(seconds)
{
    const hours = Math.floor(seconds / 3600);
    const minutes = Math.floor(seconds % 3600 / 60);

    return hours > 0 ? `${hours}h:${minutes}m` : `${minutes}m`;
}