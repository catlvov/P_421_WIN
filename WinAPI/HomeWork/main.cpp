#include <windows.h>
#include <commctrl.h>
#include <tchar.h>

#define IDC_EDIT_LOGIN      1001
#define IDC_LISTBOX         1002
#define IDC_BUTTON_ADD      1003
#define IDC_BUTTON_DELETE   1004
#define IDC_EDIT_ITEM       1005

#define IDD_MAIN_DLG        101
#define IDD_ADD_DLG         102

typedef struct {
	TCHAR szText[64];
} LIST_ITEM, *PLIST_ITEM;


HINSTANCE g_hInst;


INT_PTR CALLBACK AddItemDialogProc(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_INITDIALOG:
		SetDlgItemText(hDlg, IDC_EDIT_ITEM, TEXT(""));
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK)
		{
			TCHAR buffer[256];
			GetDlgItemText(hDlg, IDC_EDIT_ITEM, buffer, 256);


			HWND hParent = GetParent(hDlg);
			SendMessage(hParent, WM_APP, 0, (LPARAM)_tcsdup(buffer));

			EndDialog(hDlg, IDOK);
			return (INT_PTR)TRUE;
		}
		else if (LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, IDCANCEL);
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}


INT_PTR CALLBACK MainDialogProc(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_INITDIALOG:
	{
		SetDlgItemText(hDlg, IDC_EDIT_LOGIN, TEXT("¬ведите им€ пользовател€"));


		HWND hListBox = GetDlgItem(hDlg, IDC_LISTBOX);


		TCHAR* initItems[] = {
			TEXT("Ёлемент 1"),
			TEXT("Ёлемент 2"),
			TEXT("Ёлемент 3"),
			TEXT("Ёлемент 4"),
			TEXT("Ёлемент 5")
		};

		for (int i = 0; i < 5; i++)
		{
			PLIST_ITEM pItem = (PLIST_ITEM)malloc(sizeof(LIST_ITEM));
			if (pItem)
			{
				_tcscpy_s(pItem->szText, initItems[i]);
				int index = (int)SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)pItem->szText);
				SendMessage(hListBox, LB_SETITEMDATA, index, (LPARAM)pItem);
			}
		}
		return (INT_PTR)TRUE;
	}

	case WM_APP:
	{
		TCHAR* newText = (TCHAR*)lParam;
		if (newText && _tcslen(newText) > 0)
		{
			HWND hListBox = GetDlgItem(hDlg, IDC_LISTBOX);

			PLIST_ITEM pItem = (PLIST_ITEM)malloc(sizeof(LIST_ITEM));
			if (pItem)
			{
				_tcscpy_s(pItem->szText, newText);
				int index = (int)SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)pItem->szText);
				SendMessage(hListBox, LB_SETITEMDATA, index, (LPARAM)pItem);
			}
			free(newText);
		}
		return (INT_PTR)TRUE;
	}

	case WM_COMMAND:
	{
		int wmId = LOWORD(wParam);
		int wmNotification = HIWORD(wParam);


		if (wmId == IDC_EDIT_LOGIN)
		{
			static TCHAR szUserLogin[256] = TEXT("");

			switch (wmNotification)
			{
			case EN_SETFOCUS:
			{
				TCHAR currentText[256];
				GetDlgItemText(hDlg, IDC_EDIT_LOGIN, currentText, 256);
				if (_tcscmp(currentText, TEXT("¬ведите им€ пользовател€")) == 0)
				{
					SetDlgItemText(hDlg, IDC_EDIT_LOGIN, TEXT(""));
				}
				break;
			}

			case EN_KILLFOCUS:
			{
				TCHAR currentText[256];
				GetDlgItemText(hDlg, IDC_EDIT_LOGIN, currentText, 256);

				if (lstrlen(currentText) == 0)
				{
					SetDlgItemText(hDlg, IDC_EDIT_LOGIN, TEXT("¬ведите им€ пользовател€"));
				}
				else
				{
					_tcscpy_s(szUserLogin, currentText);
				}
				break;
			}
			}
			return (INT_PTR)TRUE;
		}


		if (wmId == IDC_BUTTON_ADD)
		{
			DialogBox(g_hInst, MAKEINTRESOURCE(IDD_ADD_DLG), hDlg, AddItemDialogProc);
			return (INT_PTR)TRUE;
		}


		if (wmId == IDC_BUTTON_DELETE)
		{
			HWND hListBox = GetDlgItem(hDlg, IDC_LISTBOX);
			int selectedIndex = (int)SendMessage(hListBox, LB_GETCURSEL, 0, 0);

			if (selectedIndex != LB_ERR)
			{

				PLIST_ITEM pItem = (PLIST_ITEM)SendMessage(hListBox, LB_GETITEMDATA, selectedIndex, 0);
				if (pItem)
					free(pItem);


				SendMessage(hListBox, LB_DELETESTRING, selectedIndex, 0);
			}
			else
			{
				MessageBox(hDlg, TEXT("¬ыберите элемент дл€ удалени€!"),
					TEXT("ќшибка"), MB_OK | MB_ICONWARNING);
			}
			return (INT_PTR)TRUE;
		}


		if (wmId == IDOK)
		{
			EndDialog(hDlg, IDOK);
			return (INT_PTR)TRUE;
		}


		if (wmId == IDCANCEL)
		{
			EndDialog(hDlg, IDCANCEL);
			return (INT_PTR)TRUE;
		}
		break;
	}

	case WM_DESTROY:
	{

		HWND hListBox = GetDlgItem(hDlg, IDC_LISTBOX);
		int count = (int)SendMessage(hListBox, LB_GETCOUNT, 0, 0);
		for (int i = 0; i < count; i++)
		{
			PLIST_ITEM pItem = (PLIST_ITEM)SendMessage(hListBox, LB_GETITEMDATA, i, 0);
			if (pItem)
				free(pItem);
		}
		return (INT_PTR)TRUE;
	}
	}

	return (INT_PTR)FALSE;
}

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	g_hInst = hInstance;

	INITCOMMONCONTROLSEX icex;
	icex.dwSize = sizeof(INITCOMMONCONTROLSEX);
	icex.dwICC = ICC_STANDARD_CLASSES;
	InitCommonControlsEx(&icex);

	DialogBox(hInstance, MAKEINTRESOURCE(IDD_MAIN_DLG), NULL, MainDialogProc);

	return 0;
}
