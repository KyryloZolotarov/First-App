import { createSelector } from '@ngrx/store';
import { AppState } from '../reducers/app-reducer';

export const selectAddCardModalState = (state: AppState) => state.addCardModal;

export const selectIsAddCardModalOpen = createSelector(
  selectAddCardModalState,
  (modalState) => modalState.isOpen
);