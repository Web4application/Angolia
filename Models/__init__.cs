// model handle image descriptions and metadata.
public class Product {
    public string ObjectID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string ImageTags { get; set; } // For Vision search
}
