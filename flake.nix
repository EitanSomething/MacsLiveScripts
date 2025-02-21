{
  description = "Nix flake python development environment";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-24.11";
  };

   outputs = { self, nixpkgs }:
    let
      supportedSystems = [ "x86_64-linux"];
      forEachSupportedSystem = f: nixpkgs.lib.genAttrs supportedSystems (system: f {
        pkgs = import nixpkgs { inherit system; };
      });
    in
    {
      devShells = forEachSupportedSystem ({ pkgs }: {
        default = pkgs.mkShell {
          venvDir = ".venv";
          packages = with pkgs; [ python312 ] ++
            (with pkgs.python312Packages; [
              pip
              venvShellHook
              requests
            ]);
        };
      });
    };
}
