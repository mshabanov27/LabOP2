class SystemsPrinter:
    @staticmethod
    def print_system(lin_system):
        print('System:')
        print(f'{lin_system}')

    @staticmethod
    def print_roots(roots):
        if roots is not None:
            i = 0
            for root in roots:
                print(f'{chr(i + 120)} = {round(root, 3)}')
                i += 1
            print('\n')
        else:
            print('Equation has infinite roots')
