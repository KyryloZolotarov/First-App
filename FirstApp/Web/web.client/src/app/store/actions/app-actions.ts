import { createAction } from '@ngrx/store';

export const openEditCardModal = createAction('[Modal] Open');
export const closeEditCardModal = createAction('[Modal] Close');

export const openAddCardModal = createAction('[Modal] Open');
export const closeAddCardModal = createAction('[Modal] Close');