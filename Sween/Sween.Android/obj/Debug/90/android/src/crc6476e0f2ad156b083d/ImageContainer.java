package crc6476e0f2ad156b083d;


public class ImageContainer
	extends android.widget.ImageView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_draw:(Landroid/graphics/Canvas;)V:GetDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.SfImageEditor.Android.ImageContainer, Syncfusion.SfImageEditor.XForms.Android", ImageContainer.class, __md_methods);
	}


	public ImageContainer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ImageContainer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfImageEditor.Android.ImageContainer, Syncfusion.SfImageEditor.XForms.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ImageContainer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ImageContainer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfImageEditor.Android.ImageContainer, Syncfusion.SfImageEditor.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ImageContainer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ImageContainer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfImageEditor.Android.ImageContainer, Syncfusion.SfImageEditor.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ImageContainer (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == ImageContainer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfImageEditor.Android.ImageContainer, Syncfusion.SfImageEditor.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void draw (android.graphics.Canvas p0)
	{
		n_draw (p0);
	}

	private native void n_draw (android.graphics.Canvas p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
