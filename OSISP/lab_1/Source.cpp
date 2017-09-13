#include <windows.h>

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
BOOLEAN Intersects(LPRECT borders, LPRECT object);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
	LPSTR lpCmdLine, int nCmdShow)
{
	HWND hMainWnd;
	wchar_t szClassName[] = L"My Class";
	MSG msg;
	//Создаем класс главного окна приложения (WNDCLASSEX)
	WNDCLASSEX wc;
	wc.cbSize = sizeof(wc);
	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc = WndProc; //присваиваем адрес оконной процедуры lpfn
	wc.cbClsExtra = 0; // cb счетчик байтов 
	wc.cbWndExtra = 0;

	wc.hInstance = hInstance;
	wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(BLACK_BRUSH);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = szClassName;	
	wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

	if (!RegisterClassEx(&wc)) 
	{
		MessageBox(NULL, L"Cannot register class", L"Error", MB_OK);
		return 0;
	}

	hMainWnd = CreateWindow(
		szClassName, L"A Hello Application", WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,
		(HWND)NULL, (HMENU)NULL,
		(HINSTANCE)hInstance, NULL
	);
	if (!hMainWnd) 
	{
		MessageBox(NULL, L"Cannot create main window", L"Error", MB_OK);
		return 0;
	}

	ShowWindow(hMainWnd, nCmdShow);

	while (GetMessage(&msg, NULL, 0, 0)) //выход при получении сообщения о выходе
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;

}
LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT ps;
	static RECT rect;
	static RECT myRect;
	HBRUSH hBrush;	

	switch (uMsg)
	{
	case WM_CREATE:
		SetRect(&myRect, 100, 200, 200, 300);
		if (!GetSystemMetrics(SM_MOUSEWHEELPRESENT))
		{
			MessageBox(hWnd, L"Отсутвует мышка с колесиком",
				L"", MB_OK | MB_ICONINFORMATION);
			return 0;
		}
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &ps); // получаем дискриптор контекстного устройства 
		GetClientRect(hWnd, &rect); // получение размеров рабочей области 
		hBrush = (HBRUSH)GetStockObject(DC_BRUSH);
		SetDCBrushColor(hDC, RGB(0, 255, 0));
		FillRect(hDC, &myRect, hBrush);
		EndPaint(hWnd, &ps);
		break;
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		//DeleteObject(hBrush);
		PostQuitMessage(0);
		break;
	case WM_MOUSEWHEEL:
	{
		SHORT offset = 10;
		SHORT wheelDirection; // TRUE(1) -> UP\RIGHT; FALSE(-1) -> DOWN\LEFT;
		SHORT axis; // TRUE(1) -> Ox; FALSE(0) -> Oy;
		RECT destRect;
		wheelDirection = (SHORT)HIWORD(wParam) / WHEEL_DELTA;
		axis =  (SHORT)(LOWORD(wParam) &MK_SHIFT)/4;
		OffsetRect(&myRect, offset* wheelDirection*axis,
			offset* wheelDirection*(1 - axis));
		if (Intersects(&rect,&myRect))
		{
			InvalidateRect(hWnd, NULL, TRUE);
		}
		else
		{
			OffsetRect(&myRect, -offset* wheelDirection*axis,
				-offset* wheelDirection*(1 - axis));
		}
		break;
	}
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}
	return 0;
}

BOOLEAN Intersects(LPRECT borders, LPRECT object)
{
	BOOLEAN result = TRUE;
	if (object->top < borders->top || object->left<borders->left || borders->bottom<object->bottom || borders->right < object->right)
		result = FALSE;
	return result;
}

