using UnityEngine;

public class PreviewCard
{
    /// <summary>
    /// The name of the category
    /// </summary>
    public CategoryEnum Category { get; set; }

    /// <summary>
    /// The locked category's preview
    /// </summary>
    public string Preview { get; set; }

    /// <summary>
    /// The image for the close button
    /// </summary>
    public Sprite CloseButtonImage { get; set; }

    /// <summary>
    /// The image for the deck preview
    /// </summary>
    public Sprite DeckPreviewImage { get; set; }

    /// <summary>
    /// The image for the toggle check mark
    /// </summary>
    public Sprite ToggleCheckMarkImage { get; set; }

    /// <summary>
    /// The image for the buy all image
    /// </summary>
    public Sprite BuyAllButtonImage { get; set; }

    /// <summary>
    /// The locked category's Greek preview
    /// </summary>
    public string PreviewGR { get; set; }

    /// <summary>
    /// The locked category's English preview
    /// </summary>
    public string PreviewEN { get; set; }
}
