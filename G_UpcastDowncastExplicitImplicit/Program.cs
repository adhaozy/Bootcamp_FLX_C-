//Upcast Downcast
//Explicit is use of (...)
//Implicit not use (...)

static void Main() {
	int a  = 3;
	double b = a; // implitcit
	b.Dump();
	
	double c = 3.1;
	int d = (int)c; // explicit
	d.Dump();
}