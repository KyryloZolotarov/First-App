import { createAction } from '@ngrx/store';

export const openEditCardModal = createAction('[Edit Card] Open Modal');
export const closeEditCardModal = createAction('[Edit Card] Close Modal');

export const openAddCardModal = createAction('[Add Card] Open Modal');
export const closeAddCardModal = createAction('[Edit Card] Close Modal');