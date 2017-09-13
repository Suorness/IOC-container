#include <windows.h>

#define TIMER 1
const int COUNT=3;

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
	LPSTR lpCmdLine, int nCmdShow)
{
	HWND hMainWnd;
	wchar_t szClassName[] = L"MyClass";
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
		szClassName, L"Lab_1_2", WS_OVERLAPPEDWINDOW,
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
	static POINT Pt[COUNT];
	HBRUSH NewBrush;
	static POINT offsetPt;
	BOOLEAN result;
	switch (uMsg)
	{
	case WM_CREATE:
		Pt[0].x = 125; 
		Pt[0].y = 10;
		Pt[1].x = 95; 
		Pt[1].y = 70;
		Pt[2].x = 155; 
		Pt[2].y = 70;
		offsetPt.x = 5;
		offsetPt.y = 7;
		SetTimer(hWnd, TIMER, 100, NULL);
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &ps); // получаем дискриптор контекстного устройства 
		GetClientRect(hWnd, &rect); // получение размеров рабочей области 
		NewBrush = CreateSolidBrush(RGB(0, 255, 0));
		SelectObject(hDC, NewBrush);
		Polygon(hDC, Pt, COUNT);
		DeleteObject(NewBrush);
		EndPaint(hWnd, &ps);
		break;
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_TIMER:
		switch (wParam)
		{
			case TIMER:
				do
				{
					for (int i=0;i<COUNT;i++)
					{ 
						Pt[i].x += offsetPt.x;
						Pt[i].y += offsetPt.y;
					}
					result = TRUE;
					for (int i = 0; i < 3; i++)
					{
						if (Pt[i].x<rect.left || Pt[i].x>rect.right 
							|| Pt[i].y< rect.top || Pt[i].y>rect.bottom)
						{
							result = FALSE;
						}
					}
					if (!result)
					{
						for (int i = 0; i<COUNT; i++)
						{
							Pt[i].x -= offsetPt.x;
							Pt[i].y -= offsetPt.y;
						}
						offsetPt.x = rand() % 40 - 15;
						offsetPt.y = rand() % 40 - 15;
					}
				} while (result!=TRUE);
				InvalidateRect(NULL, NULL, TRUE);

				break;
		}
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}
	return 0;
}


