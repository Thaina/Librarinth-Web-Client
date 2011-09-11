using System;

namespace Open
{
	public partial class GL
	{
		/* ----------------------------- VERSION_1_1 ---------------------------- */

		internal const uint ACCUM		= 0x0100;
		internal const uint LOAD		= 0x0101;
		internal const uint RETURN	= 0x0102;
		internal const uint MULT		= 0x0103;
		internal const uint ADD		= 0x0104;
		internal const uint NEVER		= 0x0200;
		internal const uint LESS		= 0x0201;
		internal const uint EQUAL		= 0x0202;
		internal const uint LEQUAL	= 0x0203;
		internal const uint GREATER	= 0x0204;
		internal const uint NOTEQUAL	= 0x0205;
		internal const uint GEQUAL	= 0x0206;
		internal const uint ALWAYS	= 0x0207;

		internal const uint CURRENT_BIT			= 0x00000001;
		internal const uint POINT_BIT				= 0x00000002;
		internal const uint LINE_BIT				= 0x00000004;
		internal const uint POLYGON_BIT			= 0x00000008;
		internal const uint POLYGON_STIPPLE_BIT	= 0x00000010;
		internal const uint PIXEL_MODE_BIT		= 0x00000020;
		internal const uint LIGHTING_BIT			= 0x00000040;
		internal const uint FOG_BIT				= 0x00000080;
		internal const uint DEPTH_BUFFER_BIT		= 0x00000100;
		internal const uint ACCUM_BUFFER_BIT		= 0x00000200;
		internal const uint STENCIL_BUFFER_BIT	= 0x00000400;
		internal const uint VIEWPORT_BIT			= 0x00000800;
		internal const uint TRANSFORM_BIT			= 0x00001000;
		internal const uint ENABLE_BIT			= 0x00002000;
		internal const uint COLOR_BUFFER_BIT		= 0x00004000;
		internal const uint HINT_BIT				= 0x00008000;
		internal const uint EVAL_BIT				= 0x00010000;
		internal const uint LIST_BIT				= 0x00020000;
		internal const uint TEXTURE_BIT			= 0x00040000;
		internal const uint SCISSOR_BIT			= 0x00080000;
		internal const uint ALL_ATTRIB_BITS		= 0x000fffff;

		internal const uint POINTS			= 0x0000;
		internal const uint LINES				= 0x0001;
		internal const uint LINE_LOOP			= 0x0002;
		internal const uint LINE_STRIP		= 0x0003;
		internal const uint TRIANGLES			= 0x0004;
		internal const uint TRIANGLE_STRIP	= 0x0005;
		internal const uint TRIANGLE_FAN		= 0x0006;
		internal const uint QUADS				= 0x0007;
		internal const uint QUAD_STRIP		= 0x0008;
		internal const uint POLYGON			= 0x0009;

		internal const uint ZERO	= 0;
		internal const uint ONE	= 1;

		internal const uint SRC_COLOR				= 0x0300;
		internal const uint ONE_MINUS_SRC_COLOR	= 0x0301;
		internal const uint SRC_ALPHA				= 0x0302;
		internal const uint ONE_MINUS_SRC_ALPHA	= 0x0303;
		internal const uint DST_ALPHA				= 0x0304;
		internal const uint ONE_MINUS_DST_ALPHA	= 0x0305;
		internal const uint DST_COLOR				= 0x0306;
		internal const uint ONE_MINUS_DST_COLOR	= 0x0307;
		internal const uint SRC_ALPHA_SATURATE	= 0x0308;

		internal const uint TRUE	= 1;
		internal const uint FALSE	= 0;

		internal const uint CLIP_PLANE0	= 0x3000;
		internal const uint CLIP_PLANE1	= 0x3001;
		internal const uint CLIP_PLANE2	= 0x3002;
		internal const uint CLIP_PLANE3	= 0x3003;
		internal const uint CLIP_PLANE4	= 0x3004;
		internal const uint CLIP_PLANE5	= 0x3005;

		internal const uint BYTE				= 0x1400;
		internal const uint UNSIGNED_BYTE		= 0x1401;
		internal const uint SHORT				= 0x1402;
		internal const uint UNSIGNED_SHORT	= 0x1403;
		internal const uint INT				= 0x1404;
		internal const uint UNSIGNED_INT		= 0x1405;
		internal const uint FLOAT				= 0x1406;
		internal const uint _2_BYTES			= 0x1407;
		internal const uint _3_BYTES			= 0x1408;
		internal const uint _4_BYTES			= 0x1409;
		internal const uint DOUBLE			= 0x140A;

		internal const uint NONE	= 0;

		internal const uint FRONT_LEFT		= 0x0400;
		internal const uint FRONT_RIGHT		= 0x0401;
		internal const uint BACK_LEFT			= 0x0402;
		internal const uint BACK_RIGHT		= 0x0403;
		internal const uint FRONT				= 0x0404;
		internal const uint BACK				= 0x0405;
		internal const uint LEFT				= 0x0406;
		internal const uint RIGHT				= 0x0407;
		internal const uint FRONT_AND_BACK	= 0x0408;
		internal const uint AUX0				= 0x0409;
		internal const uint AUX1				= 0x040A;
		internal const uint AUX2				= 0x040B;
		internal const uint AUX3				= 0x040C;

		internal const uint NO_ERROR	= 0;

		internal const uint INVALID_ENUM		= 0x0500;
		internal const uint INVALID_VALUE		= 0x0501;
		internal const uint INVALID_OPERATION	= 0x0502;
		internal const uint STACK_OVERFLOW	= 0x0503;
		internal const uint STACK_UNDERFLOW	= 0x0504;
		internal const uint OUT_OF_MEMORY		= 0x0505;

		internal const uint _2D				= 0x0600;
		internal const uint _3D				= 0x0601;
		internal const uint _3D_COLOR			= 0x0602;
		internal const uint _3D_COLOR_TEXTURE	= 0x0603;
		internal const uint _4D_COLOR_TEXTURE	= 0x0604;

		internal const uint PASS_THROUGH_TOKEN	= 0x0700;
		internal const uint POINT_TOKEN			= 0x0701;
		internal const uint LINE_TOKEN			= 0x0702;
		internal const uint POLYGON_TOKEN			= 0x0703;
		internal const uint BITMAP_TOKEN			= 0x0704;
		internal const uint DRAW_PIXEL_TOKEN		= 0x0705;
		internal const uint COPY_PIXEL_TOKEN		= 0x0706;
		internal const uint LINE_RESET_TOKEN		= 0x0707;

		internal const uint EXP	= 0x0800;
		internal const uint EXP2	= 0x0801;

		internal const uint CW	= 0x0900;
		internal const uint CCW	= 0x0901;

		internal const uint COEFF		= 0x0A00;
		internal const uint ORDER		= 0x0A01;
		internal const uint DOMAIN	= 0x0A02;

		internal const uint CURRENT_COLOR					= 0x0B00;
		internal const uint CURRENT_INDEX					= 0x0B01;
		internal const uint CURRENT_NORMAL				= 0x0B02;
		internal const uint CURRENT_TEXTURE_COORDS		= 0x0B03;
		internal const uint CURRENT_RASTER_COLOR			= 0x0B04;
		internal const uint CURRENT_RASTER_INDEX			= 0x0B05;
		internal const uint CURRENT_RASTER_TEXTURE_COORDS	= 0x0B06;
		internal const uint CURRENT_RASTER_POSITION		= 0x0B07;
		internal const uint CURRENT_RASTER_POSITION_VALID	= 0x0B08;
		internal const uint CURRENT_RASTER_DISTANCE		= 0x0B09;
		internal const uint POINT_SMOOTH					= 0x0B10;
		internal const uint POINT_SIZE					= 0x0B11;
		internal const uint POINT_SIZE_RANGE				= 0x0B12;
		internal const uint POINT_SIZE_GRANULARITY		= 0x0B13;

		internal const uint LINE_SMOOTH				= 0x0B20;
		internal const uint LINE_WIDTH				= 0x0B21;
		internal const uint LINE_WIDTH_RANGE			= 0x0B22;
		internal const uint LINE_WIDTH_GRANULARITY	= 0x0B23;
		internal const uint LINE_STIPPLE				= 0x0B24;
		internal const uint LINE_STIPPLE_PATTERN		= 0x0B25;
		internal const uint LINE_STIPPLE_REPEAT		= 0x0B26;

		internal const uint LIST_MODE			= 0x0B30;
		internal const uint MAX_LIST_NESTING	= 0x0B31;
		internal const uint LIST_BASE			= 0x0B32;
		internal const uint LIST_INDEX		= 0x0B33;

		internal const uint POLYGON_MODE		= 0x0B40;
		internal const uint POLYGON_SMOOTH	= 0x0B41;
		internal const uint POLYGON_STIPPLE	= 0x0B42;
		internal const uint EDGE_FLAG			= 0x0B43;
		internal const uint CULL_FACE			= 0x0B44;
		internal const uint CULL_FACE_MODE	= 0x0B45;
		internal const uint FRONT_FACE		= 0x0B46;

		internal const uint LIGHTING					= 0x0B50;
		internal const uint LIGHT_MODEL_LOCAL_VIEWER	= 0x0B51;
		internal const uint LIGHT_MODEL_TWO_SIDE		= 0x0B52;
		internal const uint LIGHT_MODEL_AMBIENT		= 0x0B53;
		internal const uint SHADE_MODEL				= 0x0B54;
		internal const uint COLOR_MATERIAL_FACE		= 0x0B55;
		internal const uint COLOR_MATERIAL_PARAMETER	= 0x0B56;
		internal const uint COLOR_MATERIAL			= 0x0B57;

		internal const uint FOG			= 0x0B60;
		internal const uint FOG_INDEX		= 0x0B61;
		internal const uint FOG_DENSITY	= 0x0B62;
		internal const uint FOG_START		= 0x0B63;
		internal const uint FOG_END		= 0x0B64;
		internal const uint FOG_MODE		= 0x0B65;
		internal const uint FOG_COLOR		= 0x0B66;

		internal const uint DEPTH_RANGE		= 0x0B70;
		internal const uint DEPTH_TEST		= 0x0B71;
		internal const uint DEPTH_WRITEMASK	= 0x0B72;
		internal const uint DEPTH_CLEAR_VALUE	= 0x0B73;
		internal const uint DEPTH_FUNC		= 0x0B74;

		internal const uint ACCUM_CLEAR_VALUE	= 0x0B80;

		internal const uint STENCIL_TEST				= 0x0B90;
		internal const uint STENCIL_CLEAR_VALUE		= 0x0B91;
		internal const uint STENCIL_FUNC				= 0x0B92;
		internal const uint STENCIL_VALUE_MASK		= 0x0B93;
		internal const uint STENCIL_FAIL				= 0x0B94;
		internal const uint STENCIL_PASS_DEPTH_FAIL	= 0x0B95;
		internal const uint STENCIL_PASS_DEPTH_PASS	= 0x0B96;
		internal const uint STENCIL_REF				= 0x0B97;
		internal const uint STENCIL_WRITEMASK			= 0x0B98;

		internal const uint MATRIX_MODE				= 0x0BA0;
		internal const uint NORMALIZE					= 0x0BA1;
		internal const uint VIEWPORT					= 0x0BA2;
		internal const uint MODELVIEW_STACK_DEPTH		= 0x0BA3;
		internal const uint PROJECTION_STACK_DEPTH	= 0x0BA4;
		internal const uint TEXTURE_STACK_DEPTH		= 0x0BA5;
		internal const uint MODELVIEW_MATRIX			= 0x0BA6;
		internal const uint PROJECTION_MATRIX			= 0x0BA7;
		internal const uint TEXTURE_MATRIX			= 0x0BA8;

		internal const uint ATTRIB_STACK_DEPTH		= 0x0BB0;
		internal const uint CLIENT_ATTRIB_STACK_DEPTH	= 0x0BB1;

		internal const uint ALPHA_TEST		= 0x0BC0;
		internal const uint ALPHA_TEST_FUNC	= 0x0BC1;
		internal const uint ALPHA_TEST_REF	= 0x0BC2;

		internal const uint DITHER	= 0x0BD0;

		internal const uint BLEND_DST	= 0x0BE0;
		internal const uint BLEND_SRC	= 0x0BE1;
		internal const uint BLEND		= 0x0BE2;

		internal const uint LOGIC_OP_MODE		= 0x0BF0;
		internal const uint INDEX_LOGIC_OP	= 0x0BF1;
		internal const uint COLOR_LOGIC_OP	= 0x0BF2;

		internal const uint AUX_BUFFERS	= 0x0C00;
		internal const uint DRAW_BUFFER	= 0x0C01;
		internal const uint READ_BUFFER	= 0x0C02;
		internal const uint SCISSOR_BOX	= 0x0C10;
		internal const uint SCISSOR_TEST	= 0x0C11;

		internal const uint INDEX_CLEAR_VALUE	= 0x0C20;
		internal const uint INDEX_WRITEMASK	= 0x0C21;
		internal const uint COLOR_CLEAR_VALUE	= 0x0C22;
		internal const uint COLOR_WRITEMASK	= 0x0C23;

		internal const uint INDEX_MODE	= 0x0C30;
		internal const uint RGBA_MODE		= 0x0C31;
		internal const uint DOUBLEBUFFER	= 0x0C32;
		internal const uint STEREO		= 0x0C33;

		internal const uint RENDER_MODE	= 0x0C40;

		internal const uint PERSPECTIVE_CORRECTION_HINT	= 0x0C50;
		internal const uint POINT_SMOOTH_HINT				= 0x0C51;
		internal const uint LINE_SMOOTH_HINT				= 0x0C52;
		internal const uint POLYGON_SMOOTH_HINT			= 0x0C53;
		internal const uint FOG_HINT						= 0x0C54;

		internal const uint TEXTURE_GEN_S	= 0x0C60;
		internal const uint TEXTURE_GEN_T	= 0x0C61;
		internal const uint TEXTURE_GEN_R	= 0x0C62;
		internal const uint TEXTURE_GEN_Q	= 0x0C63;

		internal const uint PIXEL_MAP_I_TO_I	= 0x0C70;
		internal const uint PIXEL_MAP_S_TO_S	= 0x0C71;
		internal const uint PIXEL_MAP_I_TO_R	= 0x0C72;
		internal const uint PIXEL_MAP_I_TO_G	= 0x0C73;
		internal const uint PIXEL_MAP_I_TO_B	= 0x0C74;
		internal const uint PIXEL_MAP_I_TO_A	= 0x0C75;
		internal const uint PIXEL_MAP_R_TO_R	= 0x0C76;
		internal const uint PIXEL_MAP_G_TO_G	= 0x0C77;
		internal const uint PIXEL_MAP_B_TO_B	= 0x0C78;
		internal const uint PIXEL_MAP_A_TO_A	= 0x0C79;

		internal const uint PIXEL_MAP_I_TO_I_SIZE	= 0x0CB0;
		internal const uint PIXEL_MAP_S_TO_S_SIZE	= 0x0CB1;
		internal const uint PIXEL_MAP_I_TO_R_SIZE	= 0x0CB2;
		internal const uint PIXEL_MAP_I_TO_G_SIZE	= 0x0CB3;
		internal const uint PIXEL_MAP_I_TO_B_SIZE	= 0x0CB4;
		internal const uint PIXEL_MAP_I_TO_A_SIZE	= 0x0CB5;
		internal const uint PIXEL_MAP_R_TO_R_SIZE	= 0x0CB6;
		internal const uint PIXEL_MAP_G_TO_G_SIZE	= 0x0CB7;
		internal const uint PIXEL_MAP_B_TO_B_SIZE	= 0x0CB8;
		internal const uint PIXEL_MAP_A_TO_A_SIZE	= 0x0CB9;

		internal const uint UNPACK_SWAP_BYTES		= 0x0CF0;
		internal const uint UNPACK_LSB_FIRST		= 0x0CF1;
		internal const uint UNPACK_ROW_LENGTH		= 0x0CF2;
		internal const uint UNPACK_SKIP_ROWS		= 0x0CF3;
		internal const uint UNPACK_SKIP_PIXELS	= 0x0CF4;
		internal const uint UNPACK_ALIGNMENT		= 0x0CF5;

		internal const uint PACK_SWAP_BYTES		= 0x0D00;
		internal const uint PACK_LSB_FIRST		= 0x0D01;
		internal const uint PACK_ROW_LENGTH		= 0x0D02;
		internal const uint PACK_SKIP_ROWS		= 0x0D03;
		internal const uint PACK_SKIP_PIXELS		= 0x0D04;
		internal const uint PACK_ALIGNMENT		= 0x0D05;

		internal const uint MAP_COLOR		= 0x0D10;
		internal const uint MAP_STENCIL	= 0x0D11;
		internal const uint INDEX_SHIFT	= 0x0D12;
		internal const uint INDEX_OFFSET	= 0x0D13;

		internal const uint RED_SCALE	= 0x0D14;
		internal const uint RED_BIAS	= 0x0D15;
		internal const uint ZOOM_X	= 0x0D16;
		internal const uint ZOOM_Y	= 0x0D17;
		internal const uint GREEN_SCALE	= 0x0D18;
		internal const uint GREEN_BIAS	= 0x0D19;
		internal const uint BLUE_SCALE	= 0x0D1A;
		internal const uint BLUE_BIAS	= 0x0D1B;
		internal const uint ALPHA_SCALE	= 0x0D1C;
		internal const uint ALPHA_BIAS	= 0x0D1D;
		internal const uint DEPTH_SCALE	= 0x0D1E;
		internal const uint DEPTH_BIAS	= 0x0D1F;
		internal const uint MAX_EVAL_ORDER	= 0x0D30;
		internal const uint MAX_LIGHTS	= 0x0D31;
		internal const uint MAX_CLIP_PLANES	= 0x0D32;
		internal const uint MAX_TEXTURE_SIZE	= 0x0D33;
		internal const uint MAX_PIXEL_MAP_TABLE	= 0x0D34;
		internal const uint MAX_ATTRIB_STACK_DEPTH	= 0x0D35;
		internal const uint MAX_MODELVIEW_STACK_DEPTH	= 0x0D36;
		internal const uint MAX_NAME_STACK_DEPTH	= 0x0D37;
		internal const uint MAX_PROJECTION_STACK_DEPTH	= 0x0D38;
		internal const uint MAX_TEXTURE_STACK_DEPTH	= 0x0D39;
		internal const uint MAX_VIEWPORT_DIMS	= 0x0D3A;
		internal const uint MAX_CLIENT_ATTRIB_STACK_DEPTH	= 0x0D3B;

		internal const uint SUBPIXEL_BITS		= 0x0D50;
		internal const uint INDEX_BITS		= 0x0D51;
		internal const uint RED_BITS			= 0x0D52;
		internal const uint GREEN_BITS		= 0x0D53;
		internal const uint BLUE_BITS			= 0x0D54;
		internal const uint ALPHA_BITS		= 0x0D55;
		internal const uint DEPTH_BITS		= 0x0D56;
		internal const uint STENCIL_BITS		= 0x0D57;
		internal const uint ACCUM_RED_BITS	= 0x0D58;
		internal const uint ACCUM_GREEN_BITS	= 0x0D59;
		internal const uint ACCUM_BLUE_BITS	= 0x0D5A;
		internal const uint ACCUM_ALPHA_BITS	= 0x0D5B;

		internal const uint NAME_STACK_DEPTH	= 0x0D70;

		internal const uint AUTO_NORMAL	= 0x0D80;
		internal const uint MAP1_COLOR_4	= 0x0D90;
		internal const uint MAP1_INDEX	= 0x0D91;
		internal const uint MAP1_NORMAL	= 0x0D92;
		internal const uint MAP1_TEXTURE_COORD_1	= 0x0D93;
		internal const uint MAP1_TEXTURE_COORD_2	= 0x0D94;
		internal const uint MAP1_TEXTURE_COORD_3	= 0x0D95;
		internal const uint MAP1_TEXTURE_COORD_4	= 0x0D96;
		internal const uint MAP1_VERTEX_3	= 0x0D97;
		internal const uint MAP1_VERTEX_4	= 0x0D98;
		internal const uint MAP2_COLOR_4	= 0x0DB0;
		internal const uint MAP2_INDEX	= 0x0DB1;
		internal const uint MAP2_NORMAL	= 0x0DB2;
		internal const uint MAP2_TEXTURE_COORD_1	= 0x0DB3;
		internal const uint MAP2_TEXTURE_COORD_2	= 0x0DB4;
		internal const uint MAP2_TEXTURE_COORD_3	= 0x0DB5;
		internal const uint MAP2_TEXTURE_COORD_4	= 0x0DB6;
		internal const uint MAP2_VERTEX_3	= 0x0DB7;
		internal const uint MAP2_VERTEX_4	= 0x0DB8;
		internal const uint MAP1_GRID_DOMAIN	= 0x0DD0;
		internal const uint MAP1_GRID_SEGMENTS	= 0x0DD1;
		internal const uint MAP2_GRID_DOMAIN	= 0x0DD2;
		internal const uint MAP2_GRID_SEGMENTS	= 0x0DD3;
		internal const uint TEXTURE_1D	= 0x0DE0;
		internal const uint TEXTURE_2D	= 0x0DE1;
		internal const uint FEEDBACK_BUFFER_POINTER	= 0x0DF0;
		internal const uint FEEDBACK_BUFFER_SIZE	= 0x0DF1;
		internal const uint FEEDBACK_BUFFER_TYPE	= 0x0DF2;
		internal const uint SELECTION_BUFFER_POINTER	= 0x0DF3;
		internal const uint SELECTION_BUFFER_SIZE	= 0x0DF4;
		internal const uint TEXTURE_WIDTH	= 0x1000;
		internal const uint TEXTURE_HEIGHT	= 0x1001;
		internal const uint TEXTURE_INTERNAL_FORMAT	= 0x1003;
		internal const uint TEXTURE_BORDER_COLOR	= 0x1004;
		internal const uint TEXTURE_BORDER	= 0x1005;
		internal const uint DONT_CARE	= 0x1100;
		internal const uint FASTEST	= 0x1101;
		internal const uint NICEST	= 0x1102;

		internal const uint LIGHT0	= 0x4000;
		internal const uint LIGHT1	= 0x4001;
		internal const uint LIGHT2	= 0x4002;
		internal const uint LIGHT3	= 0x4003;
		internal const uint LIGHT4	= 0x4004;
		internal const uint LIGHT5	= 0x4005;
		internal const uint LIGHT6	= 0x4006;
		internal const uint LIGHT7	= 0x4007;

		internal const uint AMBIENT				= 0x1200;
		internal const uint DIFFUSE				= 0x1201;
		internal const uint SPECULAR				= 0x1202;
		internal const uint POSITION				= 0x1203;
		internal const uint SPOT_DIRECTION		= 0x1204;
		internal const uint SPOT_EXPONENT			= 0x1205;
		internal const uint SPOT_CUTOFF			= 0x1206;
		internal const uint CONSTANT_ATTENUATION	= 0x1207;
		internal const uint LINEAR_ATTENUATION	= 0x1208;
		internal const uint QUADRATIC_ATTENUATION	= 0x1209;

		internal const uint COMPILE				= 0x1300;
		internal const uint COMPILE_AND_EXECUTE	= 0x1301;

		internal const uint CLEAR			= 0x1500;
		internal const uint AND			= 0x1501;
		internal const uint AND_REVERSE	= 0x1502;
		internal const uint COPY			= 0x1503;
		internal const uint AND_INVERTED	= 0x1504;
		internal const uint NOOP			= 0x1505;
		internal const uint XOR			= 0x1506;
		internal const uint OR			= 0x1507;
		internal const uint NOR			= 0x1508;
		internal const uint EQUIV			= 0x1509;
		internal const uint INVERT		= 0x150A;
		internal const uint OR_REVERSE	= 0x150B;
		internal const uint COPY_INVERTED	= 0x150C;
		internal const uint OR_INVERTED	= 0x150D;
		internal const uint NAND			= 0x150E;
		internal const uint SET			= 0x150F;

		internal const uint EMISSION				= 0x1600;
		internal const uint SHININESS				= 0x1601;
		internal const uint AMBIENT_AND_DIFFUSE	= 0x1602;
		internal const uint COLOR_INDEXES			= 0x1603;

		internal const uint MODELVIEW		= 0x1700;
		internal const uint PROJECTION	= 0x1701;
		internal const uint TEXTURE		= 0x1702;

		internal const uint COLOR		= 0x1800;
		internal const uint DEPTH		= 0x1801;
		internal const uint STENCIL	= 0x1802;

		internal const uint COLOR_INDEX		= 0x1900;
		internal const uint STENCIL_INDEX		= 0x1901;
		internal const uint DEPTH_COMPONENT	= 0x1902;
		internal const uint RED				= 0x1903;
		internal const uint GREEN				= 0x1904;
		internal const uint BLUE				= 0x1905;
		internal const uint ALPHA				= 0x1906;
		internal const uint RGB				= 0x1907;
		internal const uint RGBA				= 0x1908;
		internal const uint LUMINANCE			= 0x1909;
		internal const uint LUMINANCE_ALPHA	= 0x190A;

		internal const uint BITMAP	= 0x1A00;

		internal const uint POINT	= 0x1B00;
		internal const uint LINE	= 0x1B01;
		internal const uint FILL	= 0x1B02;

		internal const uint RENDER	= 0x1C00;
		internal const uint FEEDBACK	= 0x1C01;
		internal const uint SELECT	= 0x1C02;
		internal const uint FLAT	= 0x1D00;
		internal const uint SMOOTH	= 0x1D01;
		internal const uint KEEP	= 0x1E00;
		internal const uint REPLACE	= 0x1E01;
		internal const uint INCR	= 0x1E02;
		internal const uint DECR	= 0x1E03;
		internal const uint VENDOR	= 0x1F00;
		internal const uint RENDERER	= 0x1F01;
		internal const uint VERSION	= 0x1F02;
		internal const uint EXTENSIONS	= 0x1F03;
		internal const uint _S	= 0x2000;
		internal const uint _T	= 0x2001;
		internal const uint _R	= 0x2002;
		internal const uint _Q	= 0x2003;
		internal const uint MODULATE	= 0x2100;
		internal const uint DECAL	= 0x2101;
		internal const uint TEXTURE_ENV_MODE	= 0x2200;
		internal const uint TEXTURE_ENV_COLOR	= 0x2201;
		internal const uint TEXTURE_ENV	= 0x2300;
		internal const uint EYE_LINEAR	= 0x2400;
		internal const uint OBJECT_LINEAR	= 0x2401;
		internal const uint SPHERE_MAP	= 0x2402;
		internal const uint TEXTURE_GEN_MODE	= 0x2500;
		internal const uint OBJECT_PLANE	= 0x2501;
		internal const uint EYE_PLANE	= 0x2502;

		internal const uint NEAREST	= 0x2600;
		internal const uint LINEAR	= 0x2601;

		internal const uint NEAREST_MIPMAP_NEAREST	= 0x2700;
		internal const uint LINEAR_MIPMAP_NEAREST	= 0x2701;
		internal const uint NEAREST_MIPMAP_LINEAR	= 0x2702;
		internal const uint LINEAR_MIPMAP_LINEAR	= 0x2703;

		internal const uint TEXTURE_MAG_FILTER	= 0x2800;
		internal const uint TEXTURE_MIN_FILTER	= 0x2801;
		internal const uint TEXTURE_WRAP_S	= 0x2802;
		internal const uint TEXTURE_WRAP_T	= 0x2803;

		internal const uint CLAMP	= 0x2900;
		internal const uint REPEAT	= 0x2901;

		internal const uint CLIENT_PIXEL_STORE_BIT	= 0x00000001;
		internal const uint CLIENT_VERTEX_ARRAY_BIT	= 0x00000002;
		internal const uint CLIENT_ALL_ATTRIB_BITS	= 0xffffffff;

		internal const uint POLYGON_OFFSET_UNITS	= 0x2A00;
		internal const uint POLYGON_OFFSET_POINT	= 0x2A01;
		internal const uint POLYGON_OFFSET_LINE	= 0x2A02;
		internal const uint POLYGON_OFFSET_FILL	= 0x8037;
		internal const uint POLYGON_OFFSET_FACTOR	= 0x8038;

		internal const uint ALPHA4	= 0x803B;
		internal const uint ALPHA8	= 0x803C;
		internal const uint ALPHA12	= 0x803D;
		internal const uint ALPHA16	= 0x803E;
		internal const uint LUMINANCE4	= 0x803F;
		internal const uint LUMINANCE8	= 0x8040;
		internal const uint LUMINANCE12	= 0x8041;
		internal const uint LUMINANCE16	= 0x8042;
		internal const uint LUMINANCE4_ALPHA4	= 0x8043;
		internal const uint LUMINANCE6_ALPHA2	= 0x8044;
		internal const uint LUMINANCE8_ALPHA8	= 0x8045;
		internal const uint LUMINANCE12_ALPHA4	= 0x8046;
		internal const uint LUMINANCE12_ALPHA12	= 0x8047;
		internal const uint LUMINANCE16_ALPHA16	= 0x8048;
		internal const uint INTENSITY	= 0x8049;
		internal const uint INTENSITY4	= 0x804A;
		internal const uint INTENSITY8	= 0x804B;
		internal const uint INTENSITY12	= 0x804C;
		internal const uint INTENSITY16	= 0x804D;
		internal const uint R3_G3_B2	= 0x2A10;
		internal const uint RGB4	= 0x804F;
		internal const uint RGB5	= 0x8050;
		internal const uint RGB8	= 0x8051;
		internal const uint RGB10	= 0x8052;
		internal const uint RGB12	= 0x8053;
		internal const uint RGB16	= 0x8054;
		internal const uint RGBA2	= 0x8055;
		internal const uint RGBA4	= 0x8056;
		internal const uint RGB5_A1	= 0x8057;
		internal const uint RGBA8	= 0x8058;
		internal const uint RGB10_A2	= 0x8059;
		internal const uint RGBA12	= 0x805A;
		internal const uint RGBA16	= 0x805B;
		internal const uint TEXTURE_RED_SIZE	= 0x805C;
		internal const uint TEXTURE_GREEN_SIZE	= 0x805D;
		internal const uint TEXTURE_BLUE_SIZE	= 0x805E;
		internal const uint TEXTURE_ALPHA_SIZE	= 0x805F;
		internal const uint TEXTURE_LUMINANCE_SIZE	= 0x8060;
		internal const uint TEXTURE_INTENSITY_SIZE	= 0x8061;
		internal const uint PROXY_TEXTURE_1D	= 0x8063;
		internal const uint PROXY_TEXTURE_2D	= 0x8064;
		internal const uint TEXTURE_PRIORITY	= 0x8066;
		internal const uint TEXTURE_RESIDENT	= 0x8067;
		internal const uint TEXTURE_BINDING_1D	= 0x8068;
		internal const uint TEXTURE_BINDING_2D	= 0x8069;

		internal const uint VERTEX_ARRAY	= 0x8074;
		internal const uint NORMAL_ARRAY	= 0x8075;
		internal const uint COLOR_ARRAY	= 0x8076;
		internal const uint INDEX_ARRAY	= 0x8077;
		internal const uint TEXTURE_COORD_ARRAY	= 0x8078;
		internal const uint EDGE_FLAG_ARRAY	= 0x8079;

		internal const uint VERTEX_ARRAY_SIZE		= 0x807A;
		internal const uint VERTEX_ARRAY_TYPE		= 0x807B;
		internal const uint VERTEX_ARRAY_STRIDE	= 0x807C;

		internal const uint NORMAL_ARRAY_TYPE		= 0x807E;
		internal const uint NORMAL_ARRAY_STRIDE	= 0x807F;
		internal const uint COLOR_ARRAY_SIZE		= 0x8081;
		internal const uint COLOR_ARRAY_TYPE		= 0x8082;
		internal const uint COLOR_ARRAY_STRIDE	= 0x8083;
		internal const uint INDEX_ARRAY_TYPE		= 0x8085;
		internal const uint INDEX_ARRAY_STRIDE	= 0x8086;
		internal const uint TEXTURE_COORD_ARRAY_SIZE		= 0x8088;
		internal const uint TEXTURE_COORD_ARRAY_TYPE		= 0x8089;
		internal const uint TEXTURE_COORD_ARRAY_STRIDE	= 0x808A;
		internal const uint EDGE_FLAG_ARRAY_STRIDE	= 0x808C;

		internal const uint VERTEX_ARRAY_POINTER			= 0x808E;
		internal const uint NORMAL_ARRAY_POINTER			= 0x808F;
		internal const uint COLOR_ARRAY_POINTER			= 0x8090;
		internal const uint INDEX_ARRAY_POINTER			= 0x8091;
		internal const uint TEXTURE_COORD_ARRAY_POINTER	= 0x8092;
		internal const uint EDGE_FLAG_ARRAY_POINTER		= 0x8093;

		internal const uint V2F	= 0x2A20;
		internal const uint V3F	= 0x2A21;
		internal const uint C4UB_V2F	= 0x2A22;
		internal const uint C4UB_V3F	= 0x2A23;
		internal const uint C3F_V3F	= 0x2A24;
		internal const uint N3F_V3F	= 0x2A25;
		internal const uint C4F_N3F_V3F	= 0x2A26;
		internal const uint T2F_V3F	= 0x2A27;
		internal const uint T4F_V4F	= 0x2A28;
		internal const uint T2F_C4UB_V3F	= 0x2A29;
		internal const uint T2F_C3F_V3F	= 0x2A2A;
		internal const uint T2F_N3F_V3F	= 0x2A2B;
		internal const uint T2F_C4F_N3F_V3F	= 0x2A2C;
		internal const uint T4F_C4F_N3F_V4F	= 0x2A2D;

		internal const uint LOGIC_OP			= INDEX_LOGIC_OP;
		internal const uint TEXTURE_COMPONENTS	= TEXTURE_INTERNAL_FORMAT;

		internal const uint COLOR_INDEX1_EXT	= 0x80E2;
		internal const uint COLOR_INDEX2_EXT	= 0x80E3;
		internal const uint COLOR_INDEX4_EXT	= 0x80E4;
		internal const uint COLOR_INDEX8_EXT	= 0x80E5;
		internal const uint COLOR_INDEX12_EXT	= 0x80E6;
		internal const uint COLOR_INDEX16_EXT	= 0x80E7;

		/* ----------------------------- VERSION_1_2 ---------------------------- */

		internal const uint SMOOTH_POINT_SIZE_RANGE	= 0x0B12;
		internal const uint SMOOTH_POINT_SIZE_GRANULARITY	= 0x0B13;
		internal const uint SMOOTH_LINE_WIDTH_RANGE	= 0x0B22;
		internal const uint SMOOTH_LINE_WIDTH_GRANULARITY	= 0x0B23;
		internal const uint UNSIGNED_BYTE_3_3_2	= 0x8032;
		internal const uint UNSIGNED_SHORT_4_4_4_4	= 0x8033;
		internal const uint UNSIGNED_SHORT_5_5_5_1	= 0x8034;
		internal const uint UNSIGNED_INT_8_8_8_8	= 0x8035;
		internal const uint UNSIGNED_INT_10_10_10_2	= 0x8036;
		internal const uint RESCALE_NORMAL	= 0x803A;
		internal const uint TEXTURE_BINDING_3D	= 0x806A;
		internal const uint PACK_SKIP_IMAGES	= 0x806B;
		internal const uint PACK_IMAGE_HEIGHT	= 0x806C;
		internal const uint UNPACK_SKIP_IMAGES	= 0x806D;
		internal const uint UNPACK_IMAGE_HEIGHT	= 0x806E;
		internal const uint TEXTURE_3D	= 0x806F;
		internal const uint PROXY_TEXTURE_3D	= 0x8070;
		internal const uint TEXTURE_DEPTH	= 0x8071;
		internal const uint TEXTURE_WRAP_R	= 0x8072;
		internal const uint MAX_3D_TEXTURE_SIZE	= 0x8073;
		internal const uint BGR	= 0x80E0;
		internal const uint BGRA	= 0x80E1;
		internal const uint MAX_ELEMENTS_VERTICES	= 0x80E8;
		internal const uint MAX_ELEMENTS_INDICES	= 0x80E9;
		internal const uint CLAMP_TO_EDGE	= 0x812F;
		internal const uint TEXTURE_MIN_LOD	= 0x813A;
		internal const uint TEXTURE_MAX_LOD	= 0x813B;
		internal const uint TEXTURE_BASE_LEVEL	= 0x813C;
		internal const uint TEXTURE_MAX_LEVEL	= 0x813D;
		internal const uint LIGHT_MODEL_COLOR_CONTROL	= 0x81F8;
		internal const uint SINGLE_COLOR	= 0x81F9;
		internal const uint SEPARATE_SPECULAR_COLOR	= 0x81FA;
		internal const uint UNSIGNED_BYTE_2_3_3_REV	= 0x8362;
		internal const uint UNSIGNED_SHORT_5_6_5	= 0x8363;
		internal const uint UNSIGNED_SHORT_5_6_5_REV	= 0x8364;
		internal const uint UNSIGNED_SHORT_4_4_4_4_REV	= 0x8365;
		internal const uint UNSIGNED_SHORT_1_5_5_5_REV	= 0x8366;
		internal const uint UNSIGNED_INT_8_8_8_8_REV	= 0x8367;
		internal const uint UNSIGNED_INT_2_10_10_10_REV	= 0x8368;
		internal const uint ALIASED_POINT_SIZE_RANGE	= 0x846D;
		internal const uint ALIASED_LINE_WIDTH_RANGE	= 0x846E;

		/* ----------------------------- VERSION_1_3 ---------------------------- */

		internal const uint MULTISAMPLE	= 0x809D;
		internal const uint SAMPLE_ALPHA_TO_COVERAGE	= 0x809E;
		internal const uint SAMPLE_ALPHA_TO_ONE	= 0x809F;
		internal const uint SAMPLE_COVERAGE	= 0x80A0;
		internal const uint SAMPLE_BUFFERS	= 0x80A8;
		internal const uint SAMPLES	= 0x80A9;
		internal const uint SAMPLE_COVERAGE_VALUE	= 0x80AA;
		internal const uint SAMPLE_COVERAGE_INVERT	= 0x80AB;
		internal const uint CLAMP_TO_BORDER	= 0x812D;
		internal const uint TEXTURE0	= 0x84C0;
		internal const uint TEXTURE1	= 0x84C1;
		internal const uint TEXTURE2	= 0x84C2;
		internal const uint TEXTURE3	= 0x84C3;
		internal const uint TEXTURE4	= 0x84C4;
		internal const uint TEXTURE5	= 0x84C5;
		internal const uint TEXTURE6	= 0x84C6;
		internal const uint TEXTURE7	= 0x84C7;
		internal const uint TEXTURE8	= 0x84C8;
		internal const uint TEXTURE9	= 0x84C9;
		internal const uint TEXTURE10	= 0x84CA;
		internal const uint TEXTURE11	= 0x84CB;
		internal const uint TEXTURE12	= 0x84CC;
		internal const uint TEXTURE13	= 0x84CD;
		internal const uint TEXTURE14	= 0x84CE;
		internal const uint TEXTURE15	= 0x84CF;
		internal const uint TEXTURE16	= 0x84D0;
		internal const uint TEXTURE17	= 0x84D1;
		internal const uint TEXTURE18	= 0x84D2;
		internal const uint TEXTURE19	= 0x84D3;
		internal const uint TEXTURE20	= 0x84D4;
		internal const uint TEXTURE21	= 0x84D5;
		internal const uint TEXTURE22	= 0x84D6;
		internal const uint TEXTURE23	= 0x84D7;
		internal const uint TEXTURE24	= 0x84D8;
		internal const uint TEXTURE25	= 0x84D9;
		internal const uint TEXTURE26	= 0x84DA;
		internal const uint TEXTURE27	= 0x84DB;
		internal const uint TEXTURE28	= 0x84DC;
		internal const uint TEXTURE29	= 0x84DD;
		internal const uint TEXTURE30	= 0x84DE;
		internal const uint TEXTURE31	= 0x84DF;
		internal const uint ACTIVE_TEXTURE	= 0x84E0;
		internal const uint CLIENT_ACTIVE_TEXTURE	= 0x84E1;
		internal const uint MAX_TEXTURE_UNITS	= 0x84E2;
		internal const uint TRANSPOSE_MODELVIEW_MATRIX	= 0x84E3;
		internal const uint TRANSPOSE_PROJECTION_MATRIX	= 0x84E4;
		internal const uint TRANSPOSE_TEXTURE_MATRIX	= 0x84E5;
		internal const uint TRANSPOSE_COLOR_MATRIX	= 0x84E6;
		internal const uint SUBTRACT	= 0x84E7;
		internal const uint COMPRESSED_ALPHA	= 0x84E9;
		internal const uint COMPRESSED_LUMINANCE	= 0x84EA;
		internal const uint COMPRESSED_LUMINANCE_ALPHA	= 0x84EB;
		internal const uint COMPRESSED_INTENSITY	= 0x84EC;
		internal const uint COMPRESSED_RGB	= 0x84ED;
		internal const uint COMPRESSED_RGBA	= 0x84EE;
		internal const uint TEXTURE_COMPRESSION_HINT	= 0x84EF;
		internal const uint NORMAL_MAP	= 0x8511;
		internal const uint REFLECTION_MAP	= 0x8512;
		internal const uint TEXTURE_CUBE_MAP	= 0x8513;
		internal const uint TEXTURE_BINDING_CUBE_MAP	= 0x8514;
		internal const uint TEXTURE_CUBE_MAP_POSITIVE_X	= 0x8515;
		internal const uint TEXTURE_CUBE_MAP_NEGATIVE_X	= 0x8516;
		internal const uint TEXTURE_CUBE_MAP_POSITIVE_Y	= 0x8517;
		internal const uint TEXTURE_CUBE_MAP_NEGATIVE_Y	= 0x8518;
		internal const uint TEXTURE_CUBE_MAP_POSITIVE_Z	= 0x8519;
		internal const uint TEXTURE_CUBE_MAP_NEGATIVE_Z	= 0x851A;
		internal const uint PROXY_TEXTURE_CUBE_MAP	= 0x851B;
		internal const uint MAX_CUBE_MAP_TEXTURE_SIZE	= 0x851C;
		internal const uint COMBINE	= 0x8570;
		internal const uint COMBINE_RGB	= 0x8571;
		internal const uint COMBINE_ALPHA	= 0x8572;
		internal const uint RGB_SCALE	= 0x8573;
		internal const uint ADD_SIGNED	= 0x8574;
		internal const uint INTERPOLATE	= 0x8575;
		internal const uint CONSTANT	= 0x8576;
		internal const uint PRIMARY_COLOR	= 0x8577;
		internal const uint PREVIOUS	= 0x8578;
		internal const uint SOURCE0_RGB	= 0x8580;
		internal const uint SOURCE1_RGB	= 0x8581;
		internal const uint SOURCE2_RGB	= 0x8582;
		internal const uint SOURCE0_ALPHA	= 0x8588;
		internal const uint SOURCE1_ALPHA	= 0x8589;
		internal const uint SOURCE2_ALPHA	= 0x858A;
		internal const uint OPERAND0_RGB	= 0x8590;
		internal const uint OPERAND1_RGB	= 0x8591;
		internal const uint OPERAND2_RGB	= 0x8592;
		internal const uint OPERAND0_ALPHA	= 0x8598;
		internal const uint OPERAND1_ALPHA	= 0x8599;
		internal const uint OPERAND2_ALPHA	= 0x859A;
		internal const uint TEXTURE_COMPRESSED_IMAGE_SIZE	= 0x86A0;
		internal const uint TEXTURE_COMPRESSED	= 0x86A1;
		internal const uint NUM_COMPRESSED_TEXTURE_FORMATS	= 0x86A2;
		internal const uint COMPRESSED_TEXTURE_FORMATS	= 0x86A3;
		internal const uint DOT3_RGB	= 0x86AE;
		internal const uint DOT3_RGBA	= 0x86AF;
		internal const uint MULTISAMPLE_BIT	= 0x20000000;

		/* ----------------------------- VERSION_1_4 ---------------------------- */

		internal const uint BLEND_DST_RGB	= 0x80C8;
		internal const uint BLEND_SRC_RGB	= 0x80C9;
		internal const uint BLEND_DST_ALPHA	= 0x80CA;
		internal const uint BLEND_SRC_ALPHA	= 0x80CB;
		internal const uint POINT_SIZE_MIN	= 0x8126;
		internal const uint POINT_SIZE_MAX	= 0x8127;
		internal const uint POINT_FADE_THRESHOLD_SIZE	= 0x8128;
		internal const uint POINT_DISTANCE_ATTENUATION	= 0x8129;
		internal const uint GENERATE_MIPMAP	= 0x8191;
		internal const uint GENERATE_MIPMAP_HINT	= 0x8192;
		internal const uint DEPTH_COMPONENT16	= 0x81A5;
		internal const uint DEPTH_COMPONENT24	= 0x81A6;
		internal const uint DEPTH_COMPONENT32	= 0x81A7;
		internal const uint MIRRORED_REPEAT	= 0x8370;
		internal const uint FOG_COORDINATE_SOURCE	= 0x8450;
		internal const uint FOG_COORDINATE	= 0x8451;
		internal const uint FRAGMENT_DEPTH	= 0x8452;
		internal const uint CURRENT_FOG_COORDINATE	= 0x8453;
		internal const uint FOG_COORDINATE_ARRAY_TYPE	= 0x8454;
		internal const uint FOG_COORDINATE_ARRAY_STRIDE	= 0x8455;
		internal const uint FOG_COORDINATE_ARRAY_POINTER	= 0x8456;
		internal const uint FOG_COORDINATE_ARRAY	= 0x8457;
		internal const uint COLOR_SUM	= 0x8458;
		internal const uint CURRENT_SECONDARY_COLOR	= 0x8459;
		internal const uint SECONDARY_COLOR_ARRAY_SIZE	= 0x845A;
		internal const uint SECONDARY_COLOR_ARRAY_TYPE	= 0x845B;
		internal const uint SECONDARY_COLOR_ARRAY_STRIDE	= 0x845C;
		internal const uint SECONDARY_COLOR_ARRAY_POINTER	= 0x845D;
		internal const uint SECONDARY_COLOR_ARRAY	= 0x845E;
		internal const uint MAX_TEXTURE_LOD_BIAS	= 0x84FD;
		internal const uint TEXTURE_FILTER_CONTROL	= 0x8500;
		internal const uint TEXTURE_LOD_BIAS	= 0x8501;
		internal const uint INCR_WRAP	= 0x8507;
		internal const uint DECR_WRAP	= 0x8508;
		internal const uint TEXTURE_DEPTH_SIZE	= 0x884A;
		internal const uint DEPTH_TEXTURE_MODE	= 0x884B;
		internal const uint TEXTURE_COMPARE_MODE	= 0x884C;
		internal const uint TEXTURE_COMPARE_FUNC	= 0x884D;
		internal const uint COMPARE_R_TO_TEXTURE	= 0x884E;

		/* ----------------------------- VERSION_1_5 ---------------------------- */

		internal const uint FOG_COORD_SRC						= FOG_COORDINATE_SOURCE;
		internal const uint FOG_COORD							= FOG_COORDINATE;
		internal const uint FOG_COORD_ARRAY					= FOG_COORDINATE_ARRAY;
		internal const uint SRC0_RGB							= SOURCE0_RGB;
		internal const uint FOG_COORD_ARRAY_POINTER			= FOG_COORDINATE_ARRAY_POINTER;
		internal const uint FOG_COORD_ARRAY_TYPE				= FOG_COORDINATE_ARRAY_TYPE;
		internal const uint SRC1_ALPHA						= SOURCE1_ALPHA;
		internal const uint CURRENT_FOG_COORD					= CURRENT_FOG_COORDINATE;
		internal const uint FOG_COORD_ARRAY_STRIDE			= FOG_COORDINATE_ARRAY_STRIDE;
		internal const uint SRC0_ALPHA						= SOURCE0_ALPHA;
		internal const uint SRC1_RGB							= SOURCE1_RGB;
		internal const uint FOG_COORD_ARRAY_BUFFER_BINDING	= FOG_COORDINATE_ARRAY_BUFFER_BINDING;
		internal const uint SRC2_ALPHA						= SOURCE2_ALPHA;
		internal const uint SRC2_RGB							= SOURCE2_RGB;

		internal const uint BUFFER_SIZE	= 0x8764;
		internal const uint BUFFER_USAGE	= 0x8765;
		internal const uint QUERY_COUNTER_BITS	= 0x8864;
		internal const uint CURRENT_QUERY	= 0x8865;
		internal const uint QUERY_RESULT	= 0x8866;
		internal const uint QUERY_RESULT_AVAILABLE	= 0x8867;
		internal const uint ARRAY_BUFFER	= 0x8892;
		internal const uint ELEMENT_ARRAY_BUFFER	= 0x8893;
		internal const uint ARRAY_BUFFER_BINDING	= 0x8894;
		internal const uint ELEMENT_ARRAY_BUFFER_BINDING	= 0x8895;
		internal const uint VERTEX_ARRAY_BUFFER_BINDING	= 0x8896;
		internal const uint NORMAL_ARRAY_BUFFER_BINDING	= 0x8897;
		internal const uint COLOR_ARRAY_BUFFER_BINDING	= 0x8898;
		internal const uint INDEX_ARRAY_BUFFER_BINDING	= 0x8899;
		internal const uint TEXTURE_COORD_ARRAY_BUFFER_BINDING	= 0x889A;
		internal const uint EDGE_FLAG_ARRAY_BUFFER_BINDING	= 0x889B;
		internal const uint SECONDARY_COLOR_ARRAY_BUFFER_BINDING	= 0x889C;
		internal const uint FOG_COORDINATE_ARRAY_BUFFER_BINDING	= 0x889D;
		internal const uint WEIGHT_ARRAY_BUFFER_BINDING	= 0x889E;
		internal const uint VERTEX_ATTRIB_ARRAY_BUFFER_BINDING	= 0x889F;
		internal const uint READ_ONLY	= 0x88B8;
		internal const uint WRITE_ONLY	= 0x88B9;
		internal const uint READ_WRITE	= 0x88BA;
		internal const uint BUFFER_ACCESS	= 0x88BB;
		internal const uint BUFFER_MAPPED	= 0x88BC;
		internal const uint BUFFER_MAP_POINTER	= 0x88BD;
		internal const uint STREAM_DRAW	= 0x88E0;
		internal const uint STREAM_READ	= 0x88E1;
		internal const uint STREAM_COPY	= 0x88E2;
		internal const uint STATIC_DRAW	= 0x88E4;
		internal const uint STATIC_READ	= 0x88E5;
		internal const uint STATIC_COPY	= 0x88E6;
		internal const uint DYNAMIC_DRAW	= 0x88E8;
		internal const uint DYNAMIC_READ	= 0x88E9;
		internal const uint DYNAMIC_COPY	= 0x88EA;
		internal const uint SAMPLES_PASSED	= 0x8914;

		/* ----------------------------- VERSION_2_0 ---------------------------- */

		internal const uint BLEND_EQUATION_RGB	= 0x8009;

		internal const uint VERTEX_ATTRIB_ARRAY_ENABLED	= 0x8622;
		internal const uint VERTEX_ATTRIB_ARRAY_SIZE	= 0x8623;
		internal const uint VERTEX_ATTRIB_ARRAY_STRIDE	= 0x8624;
		internal const uint VERTEX_ATTRIB_ARRAY_TYPE	= 0x8625;
		internal const uint CURRENT_VERTEX_ATTRIB	= 0x8626;
		internal const uint VERTEX_PROGRAM_POINT_SIZE	= 0x8642;
		internal const uint VERTEX_PROGRAM_TWO_SIDE	= 0x8643;
		internal const uint VERTEX_ATTRIB_ARRAY_POINTER	= 0x8645;
		internal const uint STENCIL_BACK_FUNC	= 0x8800;
		internal const uint STENCIL_BACK_FAIL	= 0x8801;
		internal const uint STENCIL_BACK_PASS_DEPTH_FAIL	= 0x8802;
		internal const uint STENCIL_BACK_PASS_DEPTH_PASS	= 0x8803;
		internal const uint MAX_DRAW_BUFFERS	= 0x8824;
		internal const uint DRAW_BUFFER0	= 0x8825;
		internal const uint DRAW_BUFFER1	= 0x8826;
		internal const uint DRAW_BUFFER2	= 0x8827;
		internal const uint DRAW_BUFFER3	= 0x8828;
		internal const uint DRAW_BUFFER4	= 0x8829;
		internal const uint DRAW_BUFFER5	= 0x882A;
		internal const uint DRAW_BUFFER6	= 0x882B;
		internal const uint DRAW_BUFFER7	= 0x882C;
		internal const uint DRAW_BUFFER8	= 0x882D;
		internal const uint DRAW_BUFFER9	= 0x882E;
		internal const uint DRAW_BUFFER10	= 0x882F;
		internal const uint DRAW_BUFFER11	= 0x8830;
		internal const uint DRAW_BUFFER12	= 0x8831;
		internal const uint DRAW_BUFFER13	= 0x8832;
		internal const uint DRAW_BUFFER14	= 0x8833;
		internal const uint DRAW_BUFFER15	= 0x8834;
		internal const uint BLEND_EQUATION_ALPHA	= 0x883D;
		internal const uint POINT_SPRITE	= 0x8861;
		internal const uint COORD_REPLACE	= 0x8862;
		internal const uint MAX_VERTEX_ATTRIBS	= 0x8869;
		internal const uint VERTEX_ATTRIB_ARRAY_NORMALIZED	= 0x886A;
		internal const uint MAX_TEXTURE_COORDS	= 0x8871;
		internal const uint MAX_TEXTURE_IMAGE_UNITS	= 0x8872;
		internal const uint FRAGMENT_SHADER	= 0x8B30;
		internal const uint VERTEX_SHADER	= 0x8B31;
		internal const uint MAX_FRAGMENT_UNIFORM_COMPONENTS	= 0x8B49;
		internal const uint MAX_VERTEX_UNIFORM_COMPONENTS	= 0x8B4A;
		internal const uint MAX_VARYING_FLOATS	= 0x8B4B;
		internal const uint MAX_VERTEX_TEXTURE_IMAGE_UNITS	= 0x8B4C;
		internal const uint MAX_COMBINED_TEXTURE_IMAGE_UNITS	= 0x8B4D;
		internal const uint SHADER_TYPE	= 0x8B4F;
		internal const uint FLOAT_VEC2	= 0x8B50;
		internal const uint FLOAT_VEC3	= 0x8B51;
		internal const uint FLOAT_VEC4	= 0x8B52;
		internal const uint INT_VEC2	= 0x8B53;
		internal const uint INT_VEC3	= 0x8B54;
		internal const uint INT_VEC4	= 0x8B55;
		internal const uint BOOL	= 0x8B56;
		internal const uint BOOL_VEC2	= 0x8B57;
		internal const uint BOOL_VEC3	= 0x8B58;
		internal const uint BOOL_VEC4	= 0x8B59;
		internal const uint FLOAT_MAT2	= 0x8B5A;
		internal const uint FLOAT_MAT3	= 0x8B5B;
		internal const uint FLOAT_MAT4	= 0x8B5C;
		internal const uint SAMPLER_1D	= 0x8B5D;
		internal const uint SAMPLER_2D	= 0x8B5E;
		internal const uint SAMPLER_3D	= 0x8B5F;
		internal const uint SAMPLER_CUBE	= 0x8B60;
		internal const uint SAMPLER_1D_SHADOW	= 0x8B61;
		internal const uint SAMPLER_2D_SHADOW	= 0x8B62;
		internal const uint DELETE_STATUS	= 0x8B80;
		internal const uint COMPILE_STATUS	= 0x8B81;
		internal const uint LINK_STATUS	= 0x8B82;
		internal const uint VALIDATE_STATUS	= 0x8B83;
		internal const uint INFO_LOG_LENGTH	= 0x8B84;
		internal const uint ATTACHED_SHADERS	= 0x8B85;
		internal const uint ACTIVE_UNIFORMS	= 0x8B86;
		internal const uint ACTIVE_UNIFORM_MAX_LENGTH	= 0x8B87;
		internal const uint SHADER_SOURCE_LENGTH	= 0x8B88;
		internal const uint ACTIVE_ATTRIBUTES	= 0x8B89;
		internal const uint ACTIVE_ATTRIBUTE_MAX_LENGTH	= 0x8B8A;
		internal const uint FRAGMENT_SHADER_DERIVATIVE_HINT	= 0x8B8B;
		internal const uint SHADING_LANGUAGE_VERSION	= 0x8B8C;
		internal const uint CURRENT_PROGRAM	= 0x8B8D;
		internal const uint POINT_SPRITE_COORD_ORIGIN	= 0x8CA0;
		internal const uint LOWER_LEFT	= 0x8CA1;
		internal const uint UPPER_LEFT	= 0x8CA2;
		internal const uint STENCIL_BACK_REF	= 0x8CA3;
		internal const uint STENCIL_BACK_VALUE_MASK	= 0x8CA4;
		internal const uint STENCIL_BACK_WRITEMASK	= 0x8CA5;

		/* ----------------------------- VERSION_2_1 ---------------------------- */

		internal const uint CURRENT_RASTER_SECONDARY_COLOR	= 0x845F;

		internal const uint PIXEL_PACK_BUFFER				= 0x88EB;
		internal const uint PIXEL_UNPACK_BUFFER			= 0x88EC;
		internal const uint PIXEL_PACK_BUFFER_BINDING		= 0x88ED;
		internal const uint PIXEL_UNPACK_BUFFER_BINDING	= 0x88EF;

		internal const uint FLOAT_MAT2x3	= 0x8B65;
		internal const uint FLOAT_MAT2x4	= 0x8B66;
		internal const uint FLOAT_MAT3x2	= 0x8B67;
		internal const uint FLOAT_MAT3x4	= 0x8B68;
		internal const uint FLOAT_MAT4x2	= 0x8B69;
		internal const uint FLOAT_MAT4x3	= 0x8B6A;

		internal const uint SRGB			= 0x8C40;
		internal const uint SRGB8			= 0x8C41;
		internal const uint SRGB_ALPHA	= 0x8C42;
		internal const uint SRGB8_ALPHA8	= 0x8C43;

		internal const uint SLUMINANCE_ALPHA		= 0x8C44;
		internal const uint SLUMINANCE8_ALPHA8	= 0x8C45;
		internal const uint SLUMINANCE			= 0x8C46;
		internal const uint SLUMINANCE8			= 0x8C47;

		internal const uint COMPRESSED_SRGB				= 0x8C48;
		internal const uint COMPRESSED_SRGB_ALPHA			= 0x8C49;
		internal const uint COMPRESSED_SLUMINANCE			= 0x8C4A;
		internal const uint COMPRESSED_SLUMINANCE_ALPHA	= 0x8C4B;
	}
}